using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DropInteraction : InteractionBase, IDropHandler
{
    public Func<GameObject, bool> dropFilter { get; set; }

    public void OnDrop(PointerEventData eventData)
    {
        if (dropFilter(eventData.selectedObject))
        {
            this.OnInteractionSuccess();
        }
        else
        {
            this.OnInteractionFail();
        }
    }

}
