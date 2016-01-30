using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class BehaviourPressButton : MonoBehaviour, IPointerClickHandler 
{
    public GameObject redLED;
    public GameObject greenLED;
    public int remainingClicks;

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();

        remainingClicks -= 1;
        
        if (remainingClicks <= 0 )
        {
            if (!greenLED.activeSelf)
            {
                // We hide the red button and show the green one
                redLED.SetActive(false);
                greenLED.SetActive(true);
                remainingClicks = 10;
            }
            else
            {
                redLED.SetActive(true);
                greenLED.SetActive(false);
                remainingClicks = 10;
            }
            
        }

        

    }
}
