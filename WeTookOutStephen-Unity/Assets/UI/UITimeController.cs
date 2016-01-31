using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UITimeController : MonoBehaviour {

    private float timeCount;
    public Text txtRef;

    // Use this for initialization
    void Start ()
    {
        timeCount = 0;
        setCountText();
    }
	
	// Update is called once per frame
	void Update () {
        timeCount = Time.time;
        setCountText();
    }

    void setCountText()
    {
        txtRef.text = "Time: " + timeCount.ToString().Split('.')[0];
    }
}
