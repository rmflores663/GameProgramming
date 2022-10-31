using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField]
    AudioSource Chime;

    [SerializeField]
    AudioSource Ouch;

    [SerializeField]
    AudioSource Boom;
    public Cloud cloud;

    public void playChime()
    {
        //Feature Point Dynamic Volume
        Chime.volume = 1.0f - Mathf.Clamp(cloud.getState()/5, 0f, 0.7f);
        Chime.Play();
    }
    public void playBoom()
    {
        Boom.volume = 0.60f;
        Boom.Play();
    }
    public void playOuch()
    {
        Ouch.volume = .5f;
        Ouch.Play();
    }
}
