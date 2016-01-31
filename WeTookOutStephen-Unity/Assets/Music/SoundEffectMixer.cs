using UnityEngine;
using System.Collections;

public class SoundEffectMixer : MonoBehaviour {

    public AudioSource asource;

    public AudioClip zoomClip;
    public AudioClip[] clips = new AudioClip[10];

    private System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playRandom()
    {
        asource.PlayOneShot(clips.RandomOrDefault());
    }

    public void playZoomSound()
    {
        asource.PlayOneShot(zoomClip);
    }
}
