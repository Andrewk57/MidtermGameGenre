using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class placementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static int money = 100;
    public GameObject prefab; 
    public static TextMeshProUGUI coins;
    private Vector3 initialPosition;
    public static float clickPower = 1f;

    private void Start()
    {
        initialPosition = transform.position; 
        coins = GameObject.Find("ccr").GetComponent<TextMeshProUGUI>();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (prefab.CompareTag("Spike")&& money >= 50)
        {
            this.transform.position = eventData.position;
        }
        if (prefab.CompareTag("Cata") && money >= 100)
        {
            this.transform.position = eventData.position;
        }
        if (prefab.CompareTag("Archer") && money >= 75)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (prefab.CompareTag("Spike") && money >= 50)
        {
            this.transform.position = eventData.position;
        }
        if (prefab.CompareTag("Cata") && money >= 100)
        {
            this.transform.position = eventData.position;
        }
        if (prefab.CompareTag("Archer") && money >= 75)
        {
            this.transform.position = eventData.position;
        }
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        if (prefab.CompareTag("Spike") && money >= 50)
        {
            GameObject parentObject = GameObject.Find("CanvasS");
            Instantiate(prefab, transform.position, Quaternion.identity, parentObject.transform);
            swordsmanWalking.speed -= 1f / 2f;
            money -= 50; 
            coins.text = money.ToString(); 
            Debug.Log("SpawnedTroop");
        }
        else if (prefab.CompareTag("Cata") && money >= 100)
        {
            GameObject parentObject = GameObject.Find("CanvasS");
            Instantiate(prefab, transform.position, Quaternion.identity, parentObject.transform);
            clickPower *= 4f;
            money -= 100; 
            coins.text = money.ToString(); 
            Debug.Log("SpawnedTroop");
        }
        else if (prefab.CompareTag("Archer") && money >= 75)
        {
            GameObject parentObject = GameObject.Find("CanvasS");
            Instantiate(prefab, transform.position, Quaternion.identity, parentObject.transform);
            clickPower *= 2f;
            money -= 75; 
            coins.text = money.ToString(); 
            Debug.Log("SpawnedTroop");
        }
        this.transform.position = initialPosition;
    }
}