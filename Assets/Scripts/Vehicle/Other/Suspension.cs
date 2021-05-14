﻿/*
 * This code is part of Arcade Car Physics for Unity by Saarg (2018)
 * 
 * This is distributed under the MIT Licence (see LICENSE.md for details)
 */

using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(WheelCollider))]
/*
    Okay so This scripts keeps the Wheel model aligned with the wheel collider component
    It is not perfect and sometimes depending on the model you're using or if it rains outside
    you might need to add localRotOffset euler rotation to have your wheels in place
    Just hit play and check if your wheels are the way you want and adjust localRotOffset if needed.
 */
public class Suspension : MonoBehaviour
{
    // Don't follow steer angle (used by tanks)
    public bool cancelSteerAngle = false;
    [FormerlySerializedAs("_wheelModel")] public GameObject wheelModel;
    private WheelCollider _wheelCollider;

    public Vector3 localRotOffset;

    private float _lastUpdate;

    void Start()
    {
        _lastUpdate = Time.realtimeSinceStartup;

        _wheelCollider = GetComponent<WheelCollider>();
    }

    void FixedUpdate()
    {
        // We don't really need to do this update every time, keep it at a maximum of 60FPS
        if (Time.realtimeSinceStartup - _lastUpdate < 1f / 60f)
        {
            return;
        }

        _lastUpdate = Time.realtimeSinceStartup;

        if (wheelModel && _wheelCollider)
        {
            Vector3 pos = new Vector3(0, 0, 0);
            Quaternion rot = new Quaternion();
            _wheelCollider.GetWorldPose(out pos, out rot);

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