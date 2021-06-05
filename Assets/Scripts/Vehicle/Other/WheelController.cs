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

    private float _normalStiffness;

    private bool _firstUpdateController = false;


    private AudioClip _currentAudioClip;

    [Header("Sounds")] [SerializeField] private AudioClip snow;
    [SerializeField] private AudioClip dirt;
    [SerializeField] private AudioClip ice;
    [SerializeField] private AudioClip sand;

    public void Start()
    {
        _lastUpdate = Time.realtimeSinceStartup;
        _wheelCollider = GetComponent<WheelCollider>();
        _audioSource = GetComponent<AudioSource>();
    }


    // ReSharper disable Unity.PerformanceAnalysis
    private int GetActiveTerrainTextureIdx()
    {
        WheelHit hit;
        _wheelCollider.GetGroundHit(out hit);

        if (hit.collider)
        {
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
        }

        return -1;
    }


    private void Update()
    {
        SetStiffness();
        SetCurrentData();
        PlaySound();
    }

    private void GroundStiffness(float s)
    {
        var stiffness = _normalStiffness + s;
        var forward = _wheelCollider.forwardFriction;
        var sideways = _wheelCollider.sidewaysFriction;
        forward.stiffness = stiffness;
        sideways.stiffness = stiffness;
        _wheelCollider.forwardFriction = forward;
        _wheelCollider.sidewaysFriction = sideways;
    }

    private void SetStiffness()
    {
        if (!_firstUpdateController)
        {
            _firstUpdateController = true;
            _normalStiffness = _wheelCollider.forwardFriction.stiffness;
        }
    }

    private void PlaySound()
    {
        if (_wheelCollider && _wheelCollider.isGrounded && _wheelCollider.rpm > 10 && _currentAudioClip != null)
        {
            _audioSource.clip = _currentAudioClip;
            _audioSource.volume = GameController.GetSfxVolume;
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void SetCurrentData()
    {
        var terrainIdx = GetActiveTerrainTextureIdx();
        var data = GameController.GroundStiffness(terrainIdx);
        GroundStiffness(data.GroundStiffness);
        _currentAudioClip = GetSound(data);
    }

    private AudioClip GetSound(GroundData groundData)
    {
        return groundData.GroundType switch
        {
            GroundType.Snow => snow,
            GroundType.Ice => ice,
            GroundType.Dirt => dirt,
            GroundType.OldAsphalt => dirt,
            GroundType.Sand => sand,
            _ => null
        };
    }

    private void FixedUpdate()
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