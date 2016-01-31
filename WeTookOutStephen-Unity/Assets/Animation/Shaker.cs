using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour {

    public float magnitude = 0.2f;
    public int skipFrames = 5;

    private int frame;
    private System.Random rnd = new System.Random();
    private Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {

        frame++;
        if (frame % skipFrames == 0)
        {
            transform.Translate((float)rnd.NextDouble() * magnitude - (magnitude / 2),
                (float)rnd.NextDouble() * magnitude - (magnitude / 2), 0);
            if (rnd.Next(2) == 0)
            {
                transform.position = position;
            }
        }
    }
}
