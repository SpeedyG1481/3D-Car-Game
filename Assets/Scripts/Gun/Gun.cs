using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeInvocation")]
public class Gun : MonoBehaviour
{
    [SerializeField] private Vector3 localRotationOffset;
    [SerializeField] private AudioClip gunSound;

    private ParticleSystem[] _particleSystems;

    private int _ammo = 0;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    public int Ammo
    {
        get => _ammo;
        set => _ammo = value;
    }

    void Update()
    {
        _audioSource.volume = GameController.GetSfxVolume;
        // var isFound = false;
        if (_ammo > 0)
        {
            var colliders = Physics.OverlapSphere(transform.position, 40);
            foreach (var vCollider in colliders)
            {
                if (vCollider.gameObject.CompareTag("Enemy"))
                {
                    var entity = vCollider.gameObject.GetComponent<Entity>();
                    if (entity != null && !entity.IsDead)
                    {
                        transform.LookAt(vCollider.gameObject.transform);
                        transform.localRotation *= Quaternion.Euler(localRotationOffset);
                        entity.Hit(float.MaxValue);
                        _ammo--;
                        _audioSource.PlayOneShot(gunSound, GameController.GetSfxVolume);

                        foreach (var particle in _particleSystems)
                        {
                            //if (particle.isPlaying) particle.Stop();
                            particle.Play();
                        }
                        // isFound = true;
                    }
                }
            }
        }

        // if (!isFound)
        // {
        //     transform.localRotation = Quaternion.Euler(localRotationOffset);
        // }
    }
}