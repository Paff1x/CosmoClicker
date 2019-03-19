using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image foreground;

    private Damagable damagable;

    private void Awake()
    {
        damagable = GetComponentInParent<Damagable>();
        if (damagable != null)
        {
            damagable.DamageEvent += OnDamage;
        }
    }

    private void OnDamage(Damagable obj)
    {
        foreground.fillAmount = obj.Health / obj.HealthMax;
    }

    //void Update()
    //{
    //    transform.rotation = Camera.main.transform.rotation;
    //    transform.Rotate(0, 180, 0);
    //}
}
