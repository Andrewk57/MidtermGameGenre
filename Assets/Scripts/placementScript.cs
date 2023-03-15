using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class placementScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static int money = 50;
    public GameObject prefab; 
    public static TextMeshProUGUI coins;
    private Vector3 initialPosition;
    public static float clickPower = 1f;
    public static TextMeshProUGUI mult;

    private void Start()
    {
        initialPosition = transform.position; 
        coins = GameObject.Find("ccr").GetComponent<TextMeshProUGUI>();
        mult = GameObject.Find("mult").GetComponent<TextMeshProUGUI>();
        coins.text = money.ToString();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (prefab.CompareTag("Spike")&& money >= 50)
        {
            this.transform.position = eventData.position;
        }
        if (prefab.CompareTag("Cata") && money >= 250)
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
        if (prefab.CompareTag("Cata") && money >= 250)
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
        else if (prefab.CompareTag("Cata") && money >= 250)
        {
            GameObject parentObject = GameObject.Find("CanvasS");
            Instantiate(prefab, transform.position, Quaternion.identity, parentObject.transform);
            clickPower *= 4f;
            mult.text = clickPower.ToString();
            money -= 250; 
            coins.text = money.ToString(); 
            Debug.Log("SpawnedTroop");
        }
        else if (prefab.CompareTag("Archer") && money >= 75)
        {
            GameObject parentObject = GameObject.Find("CanvasS");
            Instantiate(prefab, transform.position, Quaternion.identity, parentObject.transform);
            clickPower *= 2f;
            mult.text = clickPower.ToString();
            money -= 75; 
            coins.text = money.ToString(); 
            Debug.Log("SpawnedTroop");
        }
        this.transform.position = initialPosition;
    }
}