using UnityEngine;
using System.Collections;

public class FeedbackScaleDownGuide : MonoBehaviour {

    public float maxDistPerSecDown = 1f;
    public float maxDistPerSecClick = 1f;
    public float maxDistPerSecUp = 1f;
    public float targetScaleFactor = 0.5f;

    private Vector3 _startScale;
    private Transform _transform;
    private bool _isInteracted;
    private bool _isClick;

    void Start()
    {
        _transform = transform;
        _startScale = _transform.localScale;
    }

    void Update()
    {
        if (_isInteracted)
        {
            _transform.localScale = Vector3.MoveTowards(_transform.localScale, targetScaleFactor * _startScale, maxDistPerSecDown * Time.deltaTime);
        }
        else
        {
            _transform.localScale = Vector3.MoveTowards(_transform.localScale, _startScale, maxDistPerSecUp * Time.deltaTime);
        }
    }

    void OnInteractionStarted()
    {
        _isInteracted = true;

        StartCoroutine(ClickFeedback());
    }

    private IEnumerator ClickFeedback()
    {
        _isClick = true;
        float rem = 0.1f;
        while (rem > 0f && _transform != null)
        {
            rem -= Time.deltaTime;
            _transform.localScale = Vector3.MoveTowards(_transform.localScale, targetScaleFactor * _startScale, maxDistPerSecClick * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        _isClick = false;
    }

    void OnInteractionAborted()
    {
        _isInteracted = false;
    }
}
