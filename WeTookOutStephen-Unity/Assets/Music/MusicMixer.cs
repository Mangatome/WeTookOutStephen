using UnityEngine;
using System.Collections;

public class MusicMixer : MonoBehaviour {

    public AudioSource[] asources = new AudioSource[3];

    public AudioClip[] clips = new AudioClip[8];

    private bool nextLevelRequested = false;

    private int playingCount = 0;
    private BitArray playing;
    private System.Random rnd = new System.Random();

    private int getNextClipId()
    {
        int clipId = rnd.Next(clips.Length);
        while (playing.Get(clipId) != false)
        {
            clipId = rnd.Next(clips.Length);
        }
        return clipId;
    }

    // Use this for initialization
    void Start () {
        playing = new BitArray(clips.Length);
        playing.SetAll(false);
        int clipId = getNextClipId();
        asources[0].clip = clips[clipId];
        asources[0].Play();
        playing.Set(clipId, true);
        playingCount = 1;    	
	}
	
	// Update is called once per frame
	void Update () {
        if (nextLevelRequested && asources[0].time < 0.5)
        {
            nextLevelRequested = false;
            nextLevel();
        }
	}

    public void requestNextLevel()
    {
        nextLevelRequested = true;
    }

    // Change the music (for the next level)
    private void nextLevel()
    {
     
        int nextClipId = getNextClipId();
        // go to playing one track
        if (playingCount == 3)
        {
            asources[1].clip = null;
            asources[2].clip = null;
            asources[0].clip = clips[nextClipId];
            playing.SetAll(false);
            playing.Set(nextClipId, true);
            playingCount = 1;
        }
        else
        {
            asources[playingCount].clip = clips[nextClipId];
            playing.Set(nextClipId, true);
            playingCount++;
        }

        foreach (AudioSource asource in asources)
        {
            asource.Stop();
            if (asource.clip != null)
            {
                asource.Play();
            }
        }
    }
}
