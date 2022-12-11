using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class mouseDetect : MonoBehaviour, IDragHandler
{

    public float deltaMousePositionX = 0;
    public float deltaMousePositionY = 0;

    public void OnDrag(PointerEventData eventData)
    {
        deltaMousePositionY = eventData.delta.y;
        deltaMousePositionX = eventData.delta.x;


    }
    public void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            
            deltaMousePositionX = 0;
            deltaMousePositionY = 0;
        }
    }
}
