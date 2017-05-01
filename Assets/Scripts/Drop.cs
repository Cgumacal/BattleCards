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
        if (d != null)
        {
            d.check_location = this.transform;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit" + gameObject.name);
    }
}
