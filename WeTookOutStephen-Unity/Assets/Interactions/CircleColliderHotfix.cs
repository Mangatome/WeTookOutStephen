using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class CircleColliderHotfix : MonoBehaviour {

    private Vector3 _startLocalScale;
    private float _startRadius;
    private CircleCollider2D _collider2D;

	// Use this for initialization
	void Start () {
        _collider2D = GetComponent<CircleCollider2D>();
        _startLocalScale = transform.localScale;
        _startRadius = _collider2D.radius;
	}
	
	// Update is called once per frame
	void Update () {
        float s = transform.localScale.magnitude / _startLocalScale.magnitude;
        _collider2D.radius = _startRadius / s;
	}
}
