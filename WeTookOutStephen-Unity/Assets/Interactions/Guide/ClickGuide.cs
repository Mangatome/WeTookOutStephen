using UnityEngine;
using System.Collections;

public class ClickGuide : MonoBehaviour {
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 rotate;
        rotate.x = 0;
        rotate.y = 0;
        rotate.z = -2;
        transform.Rotate(rotate);
        
    }
}
