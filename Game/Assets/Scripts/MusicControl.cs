using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{

    public AudioSource backgroundMusic;
    public AudioClip[] myMusic;
    public event EventHandler MusicDead;
    public event EventHandler MusicRun;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.clip = myMusic[UnityEngine.Random.Range(0, myMusic.Length)];
            backgroundMusic.Play();
            if (backgroundMusic.clip == myMusic[1])
            {
                MusicDead(this, EventArgs.Empty);
            }
            else
            {
                MusicRun(this, EventArgs.Empty);
            }
        }


    }

 
}
