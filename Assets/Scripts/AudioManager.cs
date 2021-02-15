using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource buttonSrc;
    public AudioSource clickSrc;
    public AudioSource finishSrc;
    public AudioSource jumpSrc;
    public AudioSource switchSrc;

    public AudioSource musicSrc;


    public AudioClip buttonClp;
    public AudioClip clickClp;

    public AudioClip finishClp;

    public AudioClip jumpClp;

    public AudioClip switchClp;

    public AudioClip musicClp;

    public static AudioManager audioInstance;
    private void Awake()
    {
        if(audioInstance != null && audioInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        audioInstance = this; 
        DontDestroyOnLoad(this);
    }
}
