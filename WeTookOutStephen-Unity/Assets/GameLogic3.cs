using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GameLogic3 : MonoBehaviour {

    public List<Sprite> backgrounds;
    public List<Sprite> foregrounds;

    public MusicMixer musicMixer;
    public SoundEffectMixer soundMixer;

    public EventSystem eventSystem;

    public InteractionBase downUpPrefab;
    public InteractionBase clickPrefab;
    public DragAwayInteraction dragAwayPrefab;

    private SpriteRenderer _currentBackground; // order = -1
    private SpriteRenderer _nextBackground; // order = -2

    private List<SpriteRenderer> _foregroundObjects; // order > 0

    private bool _isTransitioning;

    void Start()
    {
        StartCoroutine(NextLevel());
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.anyKeyDown && !_isTransitioning)
        //{
        //    if (_foregroundObjects.Count > 0)
        //    {
        //        Destroy(_foregroundObjects[0].gameObject);
        //        _foregroundObjects.RemoveAt(0);
        //    }

        //    if (_foregroundObjects.Count == 0)
        //    {
        //        StartCoroutine(NextLevel());
        //    }
        //}
	}

    void OnContainerInteractionsCompleted(Container c)
    {
        int index = _foregroundObjects.IndexOf(c.GetComponent<SpriteRenderer>());
        if (index > -1)
        {
            Destroy(c.gameObject);
            _foregroundObjects.RemoveAt(index);
            soundMixer.playRandom();
        }

        if (_foregroundObjects.Count == 0)
        {
            StartCoroutine(NextLevel());
        }
    }

    void OnContainerStarted()
    {

    }

    private IEnumerator NextLevel()
    {
        Camera cam = Camera.main;
        eventSystem.gameObject.SetActive(false);
        
        _isTransitioning = true;
        
        // makes next background.
        _nextBackground = MakeSpriteRenderer(backgrounds.RandomOrDefault(), -2);
        Bounds b = cam.GetOrthographicBounds();
        _nextBackground.FitToBounds(new Bounds(
            b.center + new Vector3(Random.Range(1f, 4f), Random.Range(1f, 4f), 0f), 
            b.size * Random.Range(2f, 3f)),
         Space.World, true);

        // makes new foreground objects.
        int cnt = Random.Range(2, 4);
        _foregroundObjects = new List<SpriteRenderer>();
        for (int i = 0; i < cnt; i++)
        {
            StartCoroutine(SpawnAndAddForegroundObject(i, b));
        }

        // zooms out current background to be a new foreground object.
        if (_currentBackground != null)
        {
            StartCoroutine(ScaleAndAddToForegroundObject(_currentBackground));
        }

        // The next background becomes new background.
        _currentBackground = _nextBackground;
        _nextBackground.sortingOrder = -1;
        StartCoroutine(_currentBackground.transform.ScaleFrom(_currentBackground.transform.localScale * 1.5f, 1f, Ease.QuadOut));

        // music change
        musicMixer.requestNextLevel();
        soundMixer.playZoomSound();

        yield return new WaitForSeconds(1f);

        _isTransitioning = false;
        eventSystem.gameObject.SetActive(true);
    }

    private IEnumerator SpawnAndAddForegroundObject(int i, Bounds b)
    {
        // Target position & scale.
        SpriteRenderer sr = MakeSpriteRenderer(foregrounds.RandomOrDefault(), i + 1);
        _foregroundObjects.Add(sr);
        Transform t = sr.transform;
        t.position = new Vector3(
            Random.Range(b.min.x, b.max.x),
            Random.Range(b.min.y, b.max.y),
            (float)-i);
        t.localScale = Random.Range(0.3f, 1f) * Vector3.one;

        // Appear into position.
        StartCoroutine(t.ScaleFrom(t.localScale * 2f, Random.Range(0.5f, 2f), Ease.QuadInOut));
        yield return StartCoroutine(sr.Fade(Extensions.clearWhite, Color.white, Random.Range(0.5f, 2f), Ease.Linear));

        InjectInteraction(sr);
    }

    private IEnumerator ScaleAndAddToForegroundObject(SpriteRenderer sr)
    {
        Transform t = sr.transform;

        sr.sortingOrder = 0;

        yield return StartCoroutine(t.ScaleTo(Random.Range(0.3f, 0.7f) * Vector3.one, 2f));

        _foregroundObjects.Add(sr);

        InjectInteraction(sr);
        
    }

    private SpriteRenderer MakeSpriteRenderer(Sprite sprite, int order)
    {
        // GameObject
        GameObject go = new GameObject(sprite.name);

        // Transform
        go.transform.parent = transform;

        // Sprite Renderer
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sortingOrder = order;
        sr.sprite = sprite;

        // Animations.
        if (Random.value > 0.5f)
        {
            go.AddComponent<Shaker>();
        }
        else
        {
            go.AddComponent<Wobbler>();
        }

        return sr;
    }

    private Container InjectInteraction(SpriteRenderer sr)
    {
        Transform t = sr.transform;
        
        // Adding interaction and guide.
        InteractionBase spawn;
        float v = Random.value;
        float n = 1f / 3f;
        if (v < n)
        {
            spawn = Instantiate<InteractionBase>(clickPrefab);
        }
        else if (v < n * 2)
        {
            spawn = Instantiate<InteractionBase>(downUpPrefab);
        }
        else
        {
            DragAwayInteraction drag = Instantiate<DragAwayInteraction>(dragAwayPrefab);
            drag.draggedRoot = t;
            drag.minDistance = sr.bounds.extents.magnitude / t.localScale.magnitude;
            spawn = drag;
        }
        SpriteRenderer spawnSr = spawn.GetComponent<SpriteRenderer>();

        // Fits interaction collider.
        spawnSr.sortingOrder = sr.sortingOrder + 1;
        spawnSr.FitToBounds(sr.bounds, Space.Self, true);

        // Creating container.
        spawn.transform.parent = t;
        return t.gameObject.AddComponent<Container>();
    }
}
