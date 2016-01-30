using UnityEngine;
using System.Collections;

public class SpecificKeyInteraction : InteractionBase {

    public KeyCode SpecificKey;

    // Update is called once per frame
    void Update ()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey(SpecificKey))
            {
                base.OnInteractionSuccess();
            }
        }
	}
}
