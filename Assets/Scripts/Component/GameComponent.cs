using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameComponent : MonoBehaviour
{
    [SerializeField] private ComponentType componentType;
    [SerializeField] private AudioClip sound;
    private float _rotationSpeed = 60.0F;
    [SerializeField] private bool rotationDirectionY = true;
    private bool _collisionController = false;
    private float _timer = 0;
    private float _deathTimer = 1.75F;

    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        var vector3 = Vector3.up;
        if (!rotationDirectionY)
            vector3 = Vector3.left;
        transform.Rotate(vector3 * (_rotationSpeed * Time.deltaTime));
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
            _collisionController = true;
            _audioSource.volume = GameController.GetSfxVolume;
            _audioSource.PlayOneShot(sound, GameController.GetSfxVolume);
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