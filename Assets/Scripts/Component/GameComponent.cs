using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameComponent : MonoBehaviour
{
    [SerializeField] private ComponentType componentType;
    private float _rotationSpeed = 60.0F;
    [SerializeField] private bool rotationDirectionY = true;
    [SerializeField] private GameObject pointLight;
    [SerializeField] private AudioClip clip;
    private bool _collisionController = false;
    private float _timer = 0;
    private float _deathTimer = 1.75F;
    private AudioSource _audioSource;

    private QualityTypes _qualityTypes;


    private void Start()
    {
        _qualityTypes = GameController.GetCurrentQuality();
        _audioSource = GetComponent<AudioSource>();
        if (pointLight != null)
        {
            pointLight.SetActive(_qualityTypes > QualityTypes.High);
        }
    }

    private void Update()
    {
        if (_qualityTypes >= QualityTypes.Low)
        {
            var vector3 = Vector3.up;
            if (!rotationDirectionY)
                vector3 = Vector3.left;
            transform.Rotate(vector3 * (_rotationSpeed * Time.deltaTime));
        }

        DestroyEffect();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            var vehicle = other.gameObject.GetComponent<Vehicle>();
            GameController.Add(componentType, 1);
            if (!vehicle.PickedValues.ContainsKey(componentType))
                vehicle.PickedValues.Add(componentType, 1);
            else
                vehicle.PickedValues[componentType] = vehicle.PickedValues[componentType] + 1;
            if (_audioSource != null && !_audioSource.isPlaying)
            {
                _audioSource.clip = clip;
                _audioSource.volume = GameController.GetSfxVolume;
                _audioSource.PlayOneShot(clip, GameController.GetSfxVolume);
            }

            _collisionController = true;
        }
    }

    private void DestroyEffect()
    {
        if (_collisionController)
        {
            _rotationSpeed += 10.0F;
            _timer += Time.deltaTime;
            transform.localScale =
                Vector3.Lerp(transform.localScale, transform.localScale / 10000.0F,
                    Time.deltaTime * 7 / _deathTimer);
            if (_timer > _deathTimer)
            {
                Destroy(gameObject);
            }
        }
    }
}