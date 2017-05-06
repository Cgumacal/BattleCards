using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform originalPlace = null;
    public Transform check_location = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        originalPlace = this.transform.parent; //remembers what "area" the object came from
        this.transform.SetParent(this.transform.parent.parent); //sets the parent for the object being clicked'
        Instantiate(this.gameObject, this.transform.position, Quaternion.identity,originalPlace);//creates a copy of the game object...mainly to be used in the deck editor
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDrag");

        this.transform.position = eventData.position;//drags the object as long as mouse is clicked
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       Debug.Log("OnEndDrag" + this.transform.parent);
        if (check_location != originalPlace)//checks to see if the location the card is coming from is not the same place it came from
        {
             this.transform.SetParent(check_location);//if so, it is rooted to the location that it was in
        }
        else
        {
           Destroy(this.gameObject);//if not, it is destroyed
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
