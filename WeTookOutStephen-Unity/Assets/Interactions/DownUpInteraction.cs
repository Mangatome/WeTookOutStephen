using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DownUpInteraction : InteractionBase, IPointerDownHandler, IPointerUpHandler
{

    public float deltaTime;
    private float downTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        downTime = Time.time;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new NotImplementedException();

        if (Time.time - downTime >= deltaTime)
        {
            this.OnInteractionSuccess();
        }
    }
}
