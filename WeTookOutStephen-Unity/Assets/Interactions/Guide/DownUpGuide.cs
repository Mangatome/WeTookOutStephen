using UnityEngine;
using System.Collections;

public class DownUpGuide : MonoBehaviour {

    private Vector3 scaling;
    private Vector3 startScaling;

    // Use this for initialization
    void Start()
    {
        startScaling = scaling = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        scaling.x -= 0.25f;
        scaling.y -= 0.25f;
        scaling.z -= 0.25f;

        if(scaling.x < 0 || scaling.y < 0 || scaling.z < 0)
        {
            scaling = startScaling;
        }

        transform.localScale = scaling;
        
    }
}
