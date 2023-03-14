using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class placementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static int money = 100;
    public GameObject prefab; // The prefab to spawn when the sprite is dropped

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // Store the initial position of the sprite
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (money >= 100)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (money >= 100)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (money >= 100)
        {
            GameObject parentObject = GameObject.Find("newCavasForTowers");
            Vector3 lastPosition = eventData.position;
            Instantiate(prefab, lastPosition, Quaternion.identity, parentObject.transform);
            Debug.Log("SpawnedTroop");
        }
        this.transform.position = initialPosition;
    }
}