using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int scores;

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.AddScore(scores);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }
}
