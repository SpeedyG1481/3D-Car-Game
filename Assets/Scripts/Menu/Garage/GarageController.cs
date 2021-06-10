using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GarageController : MonoBehaviour
{
    [SerializeField] private GameObject[] cameraPositions;
    [SerializeField] private GameObject[] cars;

    [SerializeField] private AudioClip clip;

    private AudioSource _audioSource;
    private CinemachineVirtualCamera _virtualCamera;

    public static int TargetIndex = 0;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        GameController.CurrentPlayingCar = TargetIndex + 1;
        _audioSource.volume = GameController.GetMusicVolume;

        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }


        if (TargetIndex >= cameraPositions.Length)
        {
            TargetIndex = 0;
        }
        else if (TargetIndex < 0)
        {
            TargetIndex = cameraPositions.Length - 1;
        }

        if (TargetIndex < cameraPositions.Length && cars.Length == cameraPositions.Length)
        {
            _virtualCamera.LookAt = cars[TargetIndex].transform;
            _virtualCamera.transform.position = cameraPositions[TargetIndex].transform.position;
        }
    }
}