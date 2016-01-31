using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameLogic : MonoBehaviour {

    public List<Container> allContainers;
    public List<Sprite> allVisuals;

    private Container _currentContainer;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnContainerAndTakeOver(allContainers.Where(c => c.directContainersCount == 0).RandomOrDefault()));
	}

    private void SpawnRandomContainerAndTakeOver()
    {
        StartCoroutine(SpawnContainerAndTakeOver(allContainers.RandomOrDefault()));
    }

    private IEnumerator SpawnContainerAndTakeOver(Container container)
    {
        // Instanciates the container.
        Container c = Instantiate<Container>(container);

        // Camera color
        Camera cam = Camera.main;
        cam.backgroundColor = new Color(Random.value, Random.value, Random.value, 1f);

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

    void OnContainerStarted(Container container)
    {
        // Gives this a random appearance if it's a simple one.
        if (container.directContainersCount == 0)
        {
            SpriteRenderer sr = container.GetComponent<SpriteRenderer>();
            if (sr == null)
            {
                sr = container.gameObject.AddComponent<SpriteRenderer>();
            }
            sr.sprite = allVisuals.RandomOrDefault();
        }

        //// Direct children containers which contain stuff should get a "zoom in" proxy.
        //if (container.nestedLevel == 1 && container.directContainersCount > 0)
        //{
            
        //}
    }

    void OnContainerInteractionsCompleted(Container container)
    {
        if (container == _currentContainer)
        {
            SpawnRandomContainerAndTakeOver();
        }
    }
}
