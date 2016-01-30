using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Container : MonoBehaviour {

    public int directContainersCount
    {
        get
        {
            if (!_isInit)
            {
                Init();
            }

            return _content.Count;
        }
    }

    public IEnumerable<Container> directContainers
    {
        get
        {
            if (!_isInit)
            {
                Init();
            }

            return _content;
        }
    }
    
    private List<Container> _content;

    private List<InteractionBase> _interactions;

    private List<Resource> _yieldedResources;

    private bool _isInit;

    void Start()
    {
        Init();
        
        Refresh();

        SendMessageUpwards("OnContainerStarted", this, SendMessageOptions.RequireReceiver);
    }

    private void Init()
    {
        _content = this.GetComponentsInDirectChildren<Container>(false).ToList();
        _interactions = this.GetComponentsInDirectChildren<InteractionBase>(false).ToList();
        _yieldedResources = this.GetComponentsInDirectChildren<Resource>(false).ToList();

        foreach (InteractionBase i in _interactions)
        {
            i.gameObject.SetActive(false);
        }

        _isInit = true;
    }

    private void Refresh()
    {
        if (_content.Count == 0)
        {
            StartCoroutine(WaitForInteractions());
        }
    }

    private IEnumerator WaitForInteractions()
    {
        foreach (InteractionBase item in _interactions)
        {
            // Instanciates the interaction.
            item.gameObject.SetActive(true);
            yield return StartCoroutine(new WaitUntil(() => item.isSuccess));

            // Destroys it.
            Destroy(item);
        }
        _interactions.Clear();

        SendMessageUpwards("OnContainerInteractionsCompleted", this, SendMessageOptions.RequireReceiver);
    }

    void OnContainerInteractionsCompleted(Container c)
    {
        if (_content.Contains(c))
        {
            // Removes this container from the scene.
            _content.Remove(c);
            Destroy(c.gameObject);

            // Refreshes this container.
            Refresh();
        }
    }

    #region Gizmos

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, 0.3f);

        //if (this.GetComponentsInDirectChildren<Component>().Length > 1)
        //{
        //    Gizmos.color = Color.yellow;

        //    Gizmos.DrawWireCube(transform.position, Camera.main.orthographicSize * 1.5f * Vector3.one); 
        //}
    }

    #endregion
}
