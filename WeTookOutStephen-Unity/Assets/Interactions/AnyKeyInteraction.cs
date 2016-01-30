using UnityEngine;
using System.Collections;

public class AnyKeyInteraction : InteractionBase {

	void Update () {

        if (Input.anyKeyDown)
        {
            base.OnInteractionSuccess();
        }
	}
}
