using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GarageController : MonoBehaviour
{
    private CinemachineVirtualCamera camera;
    public GameObject[] objects;

    private int _targetIndex = 0;


    void Start()
    {
        camera = FindObjectOfType<CinemachineVirtualCamera>();
        if (camera != null && _targetIndex < objects.Length)
        {
            camera.LookAt = objects[_targetIndex].transform;
            //camera.Follow = objects[_targetIndex].transform;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _targetIndex++;
            if (_targetIndex >= objects.Length)
            {
                _targetIndex = 0;
                
            }
            camera.LookAt = objects[_targetIndex].transform;
        }
    }
}