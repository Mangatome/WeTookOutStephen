using UnityEngine;
using System.Collections;

public class InteractionBase : MonoBehaviour {

    public bool isSuccess { get; private set; }

    protected void OnInteractionSuccess()
    {
        // Marks this as a success.
        isSuccess = true;

        // Disables this object for now.
        this.gameObject.SetActive(false);
    }
}
