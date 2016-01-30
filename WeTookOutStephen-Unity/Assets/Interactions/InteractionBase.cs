using UnityEngine;
using System.Collections;

public class InteractionBase : MonoBehaviour {

    protected void OnInteractionSuccess()
    {
        // TODO: Disables this object for now.
        this.gameObject.SetActive(false);
        
        // TODO: this will alert the GameState and trigger some scene changes
    }

    protected void OnInteractionFail()
    {

    }


}
