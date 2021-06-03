using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[RequireComponent(typeof(WheelCollider)), RequireComponent(typeof(AudioSource))]
[SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeNullComparison")]
public class WheelController : MonoBehaviour
{
    public bool cancelSteerAngle = false;
    public GameObject wheelModel;
    private WheelCollider _wheelCollider;
    private AudioSource _audioSource;

    public Vector3 localRotOffset;
    private float _lastUpdate;


    private float[,,] _mSplatmapData;
    private int _mNumTextures;

    private Vector3 _currentPose;

    public void Start()
    {
        _lastUpdate = Time.realtimeSinceStartup;
        _wheelCollider = GetComponent<WheelCollider>();
        _audioSource = GetComponent<AudioSource>();
    }


    private int GetActiveTerrainTextureIdx()
    {
        WheelHit hit;
        _wheelCollider.GetGroundHit(out hit);

        var terrain = hit.collider.gameObject.GetComponent<Terrain>();

        if (terrain != null || _currentPose == null)
        {
            var mTerrainData = terrain.terrainData;
            var alphamapWidth = mTerrainData.alphamapWidth;
            var alphamapHeight = mTerrainData.alphamapHeight;
            _mSplatmapData = mTerrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
            _mNumTextures = _mSplatmapData.Length / (alphamapWidth * alphamapHeight);

            var terrainCord = ConvertToSplatMapCoordinate(terrain);
            var ret = 0;
            var comp = 0f;
            for (var i = 0; i < _mNumTextures; i++)
            {
                if (comp < _mSplatmapData[(int) terrainCord.z, (int) terrainCord.x, i])
                    ret = i;
            }

            return ret;
        }

        return -1;
    }


    private void Update()
    {
        var terrainIdx = GetActiveTerrainTextureIdx();
        //Texture numarası
        Debug.Log(terrainIdx);
    }

    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - _lastUpdate < 1f / 60f)
        {
            return;
        }

        _lastUpdate = Time.realtimeSinceStartup;

        if (wheelModel && _wheelCollider)
        {
            var pos = new Vector3(0, 0, 0);
            var rot = new Quaternion();
            _wheelCollider.GetWorldPose(out pos, out rot);
            _currentPose = pos;

            wheelModel.transform.rotation = rot;
            if (cancelSteerAngle)
                wheelModel.transform.rotation = transform.parent.rotation;

            wheelModel.transform.localRotation *= Quaternion.Euler(localRotOffset);
            wheelModel.transform.position = pos;

            WheelHit wheelHit;
            _wheelCollider.GetGroundHit(out wheelHit);
        }
    }

    private Vector3 ConvertToSplatMapCoordinate(Terrain terrain)
    {
        var vecRet = new Vector3();
        var ter = terrain;
        var terPosition = ter.transform.position;
        vecRet.x = (_currentPose.x - terPosition.x) / ter.terrainData.size.x * ter.terrainData.alphamapWidth;
        vecRet.z = (_currentPose.z - terPosition.z) / ter.terrainData.size.z * ter.terrainData.alphamapHeight;
        return vecRet;
    }
}