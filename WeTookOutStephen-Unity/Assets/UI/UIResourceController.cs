using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIResourceController : MonoBehaviour {

    private int maxValue = 10;
    private int currentValue = 0; 
    public Text txtRef;
    public Image ImgRef;

    // Use this for initialization
    void Start ()
    {
        // currentValue = Resource.getCurrentValue()
        // ImgRef = Resource.getImg()
        setCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // place here the getter method for the value of the resource
        // currentValue = Resource.getCurrentValue()
        // maxValue = Resource.getMaxValue()
        setCountText();
    }

    void setCountText()
    {
        txtRef.text = currentValue + "/" + maxValue;
    }
}
