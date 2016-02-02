using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DownInteraction : InteractionBase, IPointerDownHandler, IPointerUpHandler
{
    public float deltaTime;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnInteractionStart();
        
        StartCoroutine(WaitAndSucceed());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();

        OnInteractionAbort();
    }

    private IEnumerator WaitAndSucceed()
    {
        float elapsed = 0f;
        while (elapsed < deltaTime)
        {
            elapsed += Time.deltaTime;

            yield return 0;
        }

        OnInteractionSuccess();
    }
}
