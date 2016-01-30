﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ClickInteraction : InteractionBase, IPointerClickHandler
{
    public int remainingClicks;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ( --remainingClicks <= 0 )
        {
            this.OnInteractionSuccess();
        } 
    }
}
