using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoTo10 : ParentButton
{
    public GameObject menu;
    private Vehicle _vehicle;
    private Image _image;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip wrongSound;
    [SerializeField] private AudioClip successSound;
    
    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _image = GetComponent<Image>();
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
        if (!_vehicle.CanUseGoTo10)
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
        if (_vehicle.CanUseGoTo10)
        {
            var doubleComponentAd = new RewardedGoTo10();
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
            _vehicle.AddFuel(_vehicle.MaxFuel / 9.5F);
            _vehicle.AddHeal(_vehicle.MaxHeal / 8.75F);
            _vehicle.Handbrake = false;
            _vehicle.CanUseGoTo10 = false;
            menu.SetActive(false);
            
            _audioSource.volume = GameController.GetSfxVolume;
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(successSound, GameController.GetSfxVolume);
            }
        }
    }
}