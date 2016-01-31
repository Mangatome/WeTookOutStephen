using UnityEngine;
using System.Collections;

public class Wobbler : MonoBehaviour {

    public float maxAngle = 20;
    public float speed = 0.2f;
    private float nowAngle = 0;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (nowAngle < -maxAngle || nowAngle > maxAngle)
        {
            speed = -speed;
        }
        nowAngle += speed;
        transform.Rotate(0, 0, speed);
	}
}
