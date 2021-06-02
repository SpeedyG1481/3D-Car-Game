using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 17.5F;
    [SerializeField] private float lifeTime = 12.5F;
    private Rigidbody _rigidbody;
    private float _timer = 0;
    private float _damage = 0;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        _rigidbody.velocity += transform.forward * (speed * Time.fixedDeltaTime);
        _timer += Time.fixedDeltaTime;
        if (_timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
        Debug.Log(other.gameObject.name);
        
        if (other.CompareTag("Vehicle"))
        {
            var vehicle = other.GetComponent<Vehicle>();
            vehicle.Hit(_damage);
        }

        Destroy(gameObject);
    }
}