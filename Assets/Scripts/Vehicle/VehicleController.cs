using Cinemachine;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] tpsCameras;
    [SerializeField] private CinemachineVirtualCamera[] rightCameras;
    [SerializeField] private CinemachineVirtualCamera[] leftCameras;
    [SerializeField] private Vehicle[] vehicles;
    private int _index = 0;

    private void Awake()
    {
        if (tpsCameras.Length != vehicles.Length)
            return;


        foreach (var v in vehicles)
        {
            if (GameController.GetCurrentCar == v.VehicleEnum)
            {
                v.gameObject.SetActive(true);
                break;
            }
            _index++;
        }
    }

    private void Update()
    {
        for (var i = 0; i < leftCameras.Length; i++)
        {
            leftCameras[i].gameObject.SetActive(false);
            rightCameras[i].gameObject.SetActive(false);
            tpsCameras[i].gameObject.SetActive(false);
        }
        
        
        switch (GameController.GetCurrentCamera())
        {
            case CameraTypes.Right:
                rightCameras[_index].gameObject.SetActive(true);
                rightCameras[_index].Follow = vehicles[_index].transform;
                rightCameras[_index].LookAt = vehicles[_index].transform;
                break;
            case CameraTypes.Left:
                leftCameras[_index].gameObject.SetActive(true);
                leftCameras[_index].Follow = vehicles[_index].transform;
                leftCameras[_index].LookAt = vehicles[_index].transform;
                break;
            default:
                tpsCameras[_index].gameObject.SetActive(true);
                tpsCameras[_index].Follow = vehicles[_index].transform;
                tpsCameras[_index].LookAt = vehicles[_index].transform;
                break;
        }
    }
}