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
        if (d != null) //makes sure that the card is being dropped in an appropriate area.
        {
            d.check_location = this.transform; //applies the changes to the parent of the card
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit" + gameObject.name);
    }
}
