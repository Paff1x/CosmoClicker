using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int count;

    private Damagable _damagable;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _damagable = GetComponent<Damagable>();
        _damagable.DieEvent += OnDead;
        _damagable.HealthChangeEvent += _damagable.OnDamage;
    }

    private void OnEnable()
    {
        _rigidbody.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        _rigidbody.AddRelativeTorque(Random.insideUnitSphere * Random.Range(0f, 100f), ForceMode.Impulse);
    }

    private void OnDead(Damagable damagable)
    {
        _damagable.DieEvent -= OnDead;
        _damagable.HealthChangeEvent -= _damagable.OnDamage;

        if (!prefab)
            return;
        for (int i = 0; i < count; i++)
            Instantiate(prefab, transform.position, Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f)));
    }

}
