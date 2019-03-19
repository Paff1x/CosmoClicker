using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootTime;
    [SerializeField] private float bulletSpeed;

    private float _timerShoot = 0;
    private Vector3 _direction = Vector3.zero;
    private void Start()
    {

        StartCoroutine(ShootDelay());
    }
    IEnumerator ShootDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            Shoot();
        }
    }
    private void Shoot()
    {
        if (transform.position.y < GameManager.Instance.TopBorder && transform.position.x < GameManager.Instance.RightBorder && transform.position.y > GameManager.Instance.LeftBorder)
        {
            GameObject _bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody _rigidbody = _bullet.GetComponent<Rigidbody>();
            _rigidbody.AddRelativeForce(new Vector3(0, 0, bulletSpeed));
            _rigidbody.AddRelativeTorque(new Vector3(0, 1, 0));
        }
    }
    private void Update()
    {
        transform.LookAt(Player.Instance.transform);
        //_direction = Player.Instance.transform.position - transform.position;
        //_direction = _direction.normalized;
        //transform.forward = _direction;
        //var angles = transform.rotation.eulerAngles;
        //angles.z = -angles.y;
        //transform.rotation = Quaternion.Euler(angles);
    }
}

