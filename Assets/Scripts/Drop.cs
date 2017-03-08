using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("OnPointerEnter");
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log(eventData.pointerDrag.name + "was dropped to " + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null)
        {
            d.originalPlace = this.transform;
        }//checks if drop spot it a valid parent for the object. 
    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
