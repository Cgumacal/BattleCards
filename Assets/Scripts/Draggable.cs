using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform originalPlace = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        originalPlace = this.transform.parent; //remembers what "area" the object came from
        this.transform.SetParent(this.transform.parent.parent); //sets the parent for the object being clicked'
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        this.transform.position = eventData.position;//drags the object as long as mouse is clicked
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        Summon sum = gameObject.GetComponent<Summon>();
        sum.OnMouseUp();

        this.transform.SetParent(originalPlace);//returns object to origin spot if unclicked on an invalid place
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
