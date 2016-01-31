using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameLogic4 : MonoBehaviour {

    public List<Sprite> objectSprites;
    //public List<Sprite> foregrounds;

    //private SpriteRenderer _background;
    //private List<SpriteRenderer> _foregroundObjects;

    //private bool _isTransitioning;

    private List<SpriteRenderer> _objects;
    private float _minObjectZ = 50f;

    private bool _isTransitioning;

    public IEnumerable<SpriteRenderer> objectsInFrontOfCamera
    {
        get
        {
            return _objects.Where(o => o.transform.position.z > Camera.main.transform.position.z);
        }
    }

    void Awake()
    {
        _objects = new List<SpriteRenderer>();
    }

    void Start()
    {
        //StartCoroutine(NextLevel());

        AddObjects(5);
    }

    // Update is called once per frame
    void Update()
    {
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

    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpriteRenderer o = MakeObject(objectSprites.RandomOrDefault());

            _objects.Add(o);
        }
    }

    private SpriteRenderer MakeObject(Sprite sprite)
    {
        // GameObject
        GameObject go = new GameObject(sprite.name);

        // Transform
        Transform t = go.transform;
        t.position = new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f),
                _minObjectZ - Random.Range(5f, 20f)
            );
        _minObjectZ = t.position.z;

        // Sprite Renderer
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;

        return sr;
    }

    //private IEnumerator NextLevel()
    //{
    //    _isTransitioning = true;

    //    Camera cam = Camera.main;
    //    Transform camTr = cam.transform;

    //    // makes next background.
    //    _background = MakeSpriteRenderer(backgrounds.RandomOrDefault(), -2, 20f, 20f + camTr.position.z);
    //    Bounds b = Camera.main.GetOrthographicBounds();
    //    _background.FitToBounds(new Bounds(
    //        b.center + new Vector3(Random.Range(1f, 4f), Random.Range(1f, 4f), 0f),
    //        b.size * Random.Range(2f, 3f)),
    //     Space.World, true);

    //    //// makes new foreground objects.
    //    //int cnt = Random.Range(2, 5);
    //    //_foregroundObjects = new List<SpriteRenderer>();
    //    //for (int i = 0; i < cnt; i++)
    //    //{
    //    //    // Target position & scale.
    //    //    SpriteRenderer sr = MakeSpriteRenderer(foregrounds.RandomOrDefault(), i + 1);
    //    //    _foregroundObjects.Add(sr);
    //    //    Transform t = sr.transform;
    //    //    t.position = new Vector3(
    //    //        Random.Range(b.min.x, b.max.x),
    //    //        Random.Range(b.min.y, b.max.y),
    //    //        (float)-i);
    //    //    t.localScale = Random.Range(0.3f, 1f) * Vector3.one;

    //    //    // Appear into position.
    //    //    StartCoroutine(t.ScaleFrom(t.localScale * 2f, Random.Range(0.5f, 2f)));
    //    //    StartCoroutine(sr.Fade(Extensions.clearWhite, Color.white, Random.Range(0.5f, 2f), Ease.Linear));
    //    //}

    //    //// zooms out current background to be a new foreground object.
    //    //if (_currentBackground != null)
    //    //{
    //    //    yield return StartCoroutine(_currentBackground.transform.ScaleTo(Random.Range(0.3f, 0.7f) * Vector3.one, 2f));

    //    //    _foregroundObjects.Add(_currentBackground);
    //    //    _currentBackground.sortingOrder = 0;
    //    //}

    //    //// The next background becomes new background.
    //    //_currentBackground = _nextBackground;
    //    //_nextBackground.sortingOrder = -1;


    //    //yield return new WaitForSeconds(1f);

    //    _isTransitioning = false;
    //}

    //private SpriteRenderer MakeSpriteRenderer(Sprite sprite, int order, float maxXY, float z)
    //{
    //    // GameObject
    //    GameObject go = new GameObject(sprite.name);

    //    // Transform
    //    Transform t = go.transform;
    //    t.position = new Vector3(Random.Range(-maxXY, maxXY), Random.Range(-maxXY, maxXY), z);

    //    // Sprite Renderer
    //    SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
    //    sr.sortingOrder = order;
    //    sr.sprite = sprite;

    //    return sr;
    //}
}
