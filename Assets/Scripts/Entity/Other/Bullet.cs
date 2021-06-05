using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 17.5F;
    [SerializeField] private float lifeTime = 12.5F;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private AudioClip boomSound;

    private Rigidbody _rigidbody;
    private float _timer = 0;
    private float _damage = 0;
    private Vehicle _vehicle;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public Vehicle Vehicle
    {
        get => _vehicle;
        set => _vehicle = value;
    }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (_vehicle != null)
        {
            transform.LookAt(_vehicle.transform);
            _rigidbody.velocity += transform.forward * (speed * Time.fixedDeltaTime);
            _timer += Time.fixedDeltaTime;
            if (_timer > lifeTime)
            {
                Destroy(gameObject);
            }

            transform.Rotate(Vector3.forward * (Time.fixedDeltaTime * speed));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            var vehicle = other.gameObject.GetComponentInParent<Vehicle>();
            if (vehicle != null)
            {
                vehicle.Hit(_damage);
                if (explosionParticle)
                {
                    var go = Instantiate(explosionParticle, transform.position, transform.rotation);
                    var source = go.gameObject.AddComponent<AudioSource>();
                    source.volume = GameController.GetSfxVolume;
                    source.PlayOneShot(boomSound, GameController.GetSfxVolume);
                }

                Destroy(gameObject);
            }
        }
    }
}