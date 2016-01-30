using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    public List<Container> allContainers;

    private Container _currentContainer;

	// Use this for initialization
	void Start () {
        SpawnRandomContainerAndTakeOver();
	}

    private void SpawnRandomContainerAndTakeOver()
    {
        StartCoroutine(SpawnContainerAndTakeOver(allContainers.RandomOrDefault()));
    }

    private IEnumerator SpawnContainerAndTakeOver(Container container)
    {
        // Instanciates the container.
        Container c = Instantiate<Container>(container);

        // Brings it into view.
        Transform t = c.transform;
        t.parent = this.transform;
        t.position = Camera.main.transform.position.ReplaceZ(0f);
        yield return StartCoroutine(c.transform.ScaleFrom(Vector3.zero, 1f, Ease.Linear));

        // Destroys the current container.
        if (_currentContainer != null)
        {
            Destroy(_currentContainer.gameObject);
        }
        _currentContainer = c;
    }

    void OnContainerInteractionsCompleted(Container container)
    {
        if (container == _currentContainer)
        {
            SpawnRandomContainerAndTakeOver();
        }
    }
}
