using UnityEngine;
using UnityEngine.Purchasing;

[RequireComponent(typeof(AudioSource))]
public class IAP : MonoBehaviour, IStoreListener
{
    private static readonly string KnightRider = "com.megalowgamestudio.firtf.knightrider";
    private static readonly string Fustang = "com.megalowgamestudio.firtf.fustang";


    private IStoreController _controller;
    private IExtensionProvider _extensions;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip success;
    [SerializeField] private AudioClip wrong;

    private void Start()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("com.megalowgamestudio.firtf.knightrider", ProductType.NonConsumable);
        builder.AddProduct("com.megalowgamestudio.firtf.fustang", ProductType.NonConsumable);
        _audioSource = GetComponent<AudioSource>();
        UnityPurchasing.Initialize(this, builder);
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


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        return PurchaseProcessingResult.Complete;
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this._controller = controller;
        this._extensions = extensions;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        _audioSource.volume = GameController.GetSfxVolume;
        _audioSource.PlayOneShot(wrong, GameController.GetSfxVolume);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
    }
}