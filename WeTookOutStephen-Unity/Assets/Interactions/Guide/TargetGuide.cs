using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TargetGuide : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEndDragHandler {

    public SpriteRenderer target;

    private float alpha
    {
        get
        {
            return target.color.a;
        }

        set
        {
            Color c = target.color;
            c.a = value;
            target.color = c;
        }
    }

    private float _alphaTarget;
    private Vector3 _startTargetPos;

	// Use this for initialization
	void Start () {
        _startTargetPos = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        alpha = Mathf.MoveTowards(target.color.a, _alphaTarget, Time.deltaTime * 0.5f);
	}

    void LateUpdate()
    {
        target.transform.position = _startTargetPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _alphaTarget = 1f;
        alpha = Mathf.Max(0.3f, alpha);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _alphaTarget = 0f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _alphaTarget = 0f;
    }
}
