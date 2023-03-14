using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class placementScript : MonoBehaviour, IpointerDown, IDragHandler, IpointerUp
{
    public static int money = 100;
    public GameObject CardCataprefab; 
    public GameObject imagePrefab;
    public Canvas canvas;
    

    private void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Instantiate(imagePrefab, canvas.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
