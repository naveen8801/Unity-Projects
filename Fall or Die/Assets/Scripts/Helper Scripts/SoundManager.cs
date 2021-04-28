using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip landclip,deathclip,icebreakclip,gameoverclip,starsound;



    // Start is called before the first frame update
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LandSound()
    {
        soundFX.clip = landclip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = icebreakclip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathclip;
        soundFX.Play();
    }

    public void GameoverSound()
    {
        soundFX.clip = gameoverclip;
        soundFX.Play();
    }
    public void StarSound()
    {
        soundFX.clip = starsound;
        soundFX.Play();
    }

}
