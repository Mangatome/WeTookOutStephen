using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : MonoBehaviour {

    public List<Container> content;

    public List<InteractionBase> interactions;

    public List<Resource> yieldedResources;

    void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        if (content.Count == 0)
        {
            StartCoroutine(WaitForInteractions());
        }
    }

    private IEnumerator WaitForInteractions()
    {
        foreach (InteractionBase item in interactions)
        {
            // Instanciates the interaction.
            InteractionBase interaction = Instantiate<InteractionBase>(item);
            interaction.transform.parent = this.transform;
            yield return StartCoroutine(new WaitUntil(() => interaction.isSuccess));

            // Destroys it.
            Destroy(interaction);
        }

        SendMessageUpwards("OnContainerInteractionsCompleted", this, SendMessageOptions.RequireReceiver);
    }

    void OnContainerInteractionsCompleted(Container c)
    {
        if (content.Contains(c))
        {
            content.Remove(c);

            Destroy(c);

            Refresh();
        }
    }
}
