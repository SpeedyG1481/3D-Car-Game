using UnityEngine;
using UnityEngine.Purchasing;

[RequireComponent(typeof(AudioSource))]
public class IAP : MonoBehaviour
{
    private static readonly string KnightRider = "com.megalowgamestudio.firtf.knightrider";
    private static readonly string Fustang = "com.megalowgamestudio.firtf.fustang";


    private AudioSource _audioSource;
    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip wrong;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == Fustang)
        {
            GameController.OpenCar(Vehicles.Fustang);
            _audioSource.volume = GameController.GetSfxVolume;
            _audioSource.PlayOneShot(success, GameController.GetSfxVolume);
        }
        else if (product.definition.id == KnightRider)
        {
            _audioSource.volume = GameController.GetSfxVolume;
            _audioSource.PlayOneShot(success, GameController.GetSfxVolume);
            GameController.OpenCar(Vehicles.KnightRider);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        _audioSource.volume = GameController.GetSfxVolume;
        _audioSource.PlayOneShot(wrong, GameController.GetSfxVolume);
    }
}