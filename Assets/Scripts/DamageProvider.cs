using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProvider : MonoBehaviour
{
    [SerializeField]private float damage; 
    [SerializeField]private bool destroyAfterCollide;

    public float Damage { get { return damage; } }
    public bool DestroyAfterCollide { get { return destroyAfterCollide; } }
}
