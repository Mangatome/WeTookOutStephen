using UnityEngine;
using System.Collections;

public class SoundEffectMixer : MonoBehaviour {

    public AudioSource asource;

    public AudioClip zoomClip;
    public AudioClip[] clips = new AudioClip[10];

    public void playRandom()
    {
        asource.PlayOneShot(clips.RandomOrDefault());
    }

    public void playZoomSound()
    {
        asource.PlayOneShot(zoomClip);
    }
}
