using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Damagable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float maxHealth;

    public float Health { get; private set; }
    public float HealthMax { get { return maxHealth; } }

    public Action<Damagable> DamageEvent;
    public Action<Damagable> DieEvent;
    public Action HealthChangeEvent;

    private void Awake()
    {
        Health = maxHealth;

    }

    public void OnCollisionEnter(Collision collision)
    {
        var damageProvider = collision.collider.GetComponentInParent<DamageProvider>();
        if (damageProvider != null)
        {
            Health -= damageProvider.Damage;
            DamageEvent?.Invoke(this);

            if (Health <= 0)
            {
                DieEvent?.Invoke(this);

                Destroy(gameObject);
            }
            if (damageProvider.DestroyAfterCollide)
                Destroy(damageProvider.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HealthChangeEvent();
    }

    public void OnHeal()
    {
        if(Health < maxHealth)
        Health++;
        if (Health > maxHealth)
            Health = maxHealth;
        DamageEvent(this);
    }
    public void OnDamage()
    {
        Health--;
        if (Health <= 0)
        {
            DieEvent(this);
            Destroy(gameObject);
        }
        DamageEvent(this);
    }
}
