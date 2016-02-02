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

    protected void OnInteractionFail()
    {

    }

    protected void OnInteractionStart()
    {
        SendMessage("OnInteractionStarted", this, SendMessageOptions.DontRequireReceiver);
    }

    protected void OnInteractionAbort()
    {
        SendMessage("OnInteractionAborted", this, SendMessageOptions.DontRequireReceiver);
    }

    #region Gizmos

    void OnDrawGizmos()
    {
        Gizmos.color = this.GetTypeColor();

        Gizmos.DrawWireCube(transform.position, 0.25f * Vector3.one);
    }

    #endregion
}
