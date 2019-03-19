using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject damagePrefab;
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private bool MoveToPlayer = false;

    private Damagable _damagable;
    private Rigidbody _rigidbody;
    private Vector3 _direction = Vector3.zero;

    private void Awake()
    {
        _damagable = GetComponent<Damagable>();
        _rigidbody = GetComponent<Rigidbody>();
        _damagable.HealthChangeEvent += _damagable.OnDamage;
        _damagable.DieEvent += OnDead;
        _damagable.HealthChangeEvent += OnDamage;
    }

    private void OnEnable()
    {
        SetDirection();
    }
    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _direction * speed * Time.fixedDeltaTime);
    }

    private void OnDead(Damagable damagable)
    {
        _damagable.HealthChangeEvent -= _damagable.OnDamage;
        _damagable.DieEvent -= OnDead;
        _damagable.HealthChangeEvent -= OnDamage;
        Instantiate(collectablePrefab, transform.position, transform.rotation);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }

    private void OnDamage()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z-1);
        Instantiate(damagePrefab, position, Quaternion.identity);
    }


    private void SetDirection()
    {
        if (MoveToPlayer)
        {
            _direction = Player.Instance.transform.position - transform.position;
            _direction = _direction.normalized;
            transform.forward = _direction;
            var angles = transform.rotation.eulerAngles;
            angles.z = -angles.y;
            transform.rotation = Quaternion.Euler(angles);
        }
        else
            _direction = transform.forward;
    }
}
