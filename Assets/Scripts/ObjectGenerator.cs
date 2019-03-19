using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]private float spawnTime;

    [SerializeField] private GameObject[] prefabs;

    private Vector3 spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }
    private void Spawn()
    {
        spawnPosition = new Vector3(Random.Range(GameManager.Instance.LeftBorder, GameManager.Instance.RightBorder), 1.25f*GameManager.Instance.TopBorder, 0);

        Instantiate(prefabs[Random.Range(0,prefabs.Length)], spawnPosition, transform.rotation);
    }
}
