using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeController : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}
