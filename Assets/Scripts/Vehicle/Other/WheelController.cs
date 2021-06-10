using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class WheelController : MonoBehaviour
{
    public bool cancelSteerAngle = false;
    public GameObject wheelModel;
    private WheelCollider _wheelCollider;

    public Vector3 localRotOffset;
    private float _lastUpdate;

    private Vector3 _currentPose;

    public void Start()
    {
        _lastUpdate = Time.realtimeSinceStartup;
        _wheelCollider = GetComponent<WheelCollider>();
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
}