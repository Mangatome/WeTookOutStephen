using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragAwayInteraction : InteractionBase, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform draggedRoot;
    public float minDistance;

    private Vector3 _startPos;
    private Vector3 _cursorToCenter;
    private List<Behaviour> _animations;

    void Start()
    {
        _startPos = draggedRoot.position;

        _animations = new List<Behaviour>();
        _animations.AddRange(draggedRoot.GetComponentsInChildren<Wobbler>());
        _animations.AddRange(draggedRoot.GetComponentsInChildren<Shaker>());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetAnimationsEnabled(false);
        
        _cursorToCenter = draggedRoot.position - eventData.pointerCurrentRaycast.worldPosition;

        OnInteractionStart();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = eventData.pointerCurrentRaycast.worldPosition + _cursorToCenter;

        draggedRoot.position = newPos;

        if (Vector3.Distance(newPos, _startPos) >= minDistance)
        {
            OnInteractionSuccess();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnInteractionAbort();

        draggedRoot.position = _startPos;

        SetAnimationsEnabled(true);
    }

    private void SetAnimationsEnabled(bool enabled)
    {
        foreach (Behaviour c in _animations)
        {
            c.enabled = enabled;   
        }
    }
}
