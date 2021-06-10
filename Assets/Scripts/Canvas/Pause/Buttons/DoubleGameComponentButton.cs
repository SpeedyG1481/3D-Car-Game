using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleGameComponentButton : ParentButton
{
    public GameObject menu;
    private Vehicle _vehicle;
    private Image _image;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip wrongSound;
    [SerializeField] private AudioClip successSound;

    private void Start()
    {
        _image = GetComponent<Image>();
        _audioSource = gameObject.AddComponent<AudioSource>();
        foreach (var vehicles in FindObjectsOfType<Vehicle>())
        {
            if (vehicles.gameObject.activeInHierarchy)
            {
                _vehicle = vehicles;
            }
        }
    }

    private void Update()
    {
        if (!_vehicle.CanUseDoubleComponent)
        {
            _image.color = Color.grey;
        }
        else
        {
            _image.color = Color.white;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (_vehicle.CanUseDoubleComponent)
        {
            var doubleComponentAd = new RewardedDoubleComponent();
            doubleComponentAd.Initialize(Reward);
            base.OnPointerDown(eventData);
        }
        else
        {
            _audioSource.volume = GameController.GetSfxVolume;
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(wrongSound, GameController.GetSfxVolume);
            }
        }
    }

    private void Reward(object sender, Reward e)
    {
        if (_vehicle != null)
        {
            _vehicle.DoubleComponent();
            _vehicle.CanUseDoubleComponent = false;
            
            _audioSource.volume = GameController.GetSfxVolume;
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(successSound, GameController.GetSfxVolume);
            }
        }
    }
}