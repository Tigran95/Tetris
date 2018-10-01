using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioTypes
{
    click,
    moveDown,
    rotate,
    destroyTiles,
    lose
}

public class AudioSelecting : MonoBehaviour {


    public AudioSource clickAudio;
    public AudioSource moveDownAudio;
    public AudioSource rotateAudio;
    public AudioSource destroyTilesAudio;
    public AudioSource loseAudio;

    public static bool isCreatedThis=false;
    public void Awake()
    {
        if (!isCreatedThis)
        {
            isCreatedThis = true;
            DontDestroyOnLoad(this);
        }
      
    }
    public void ChooseAudio(AudioTypes audio)
    {
        switch (audio)
        {
            case AudioTypes.click:
                clickAudio.Play(); break;

            case AudioTypes.moveDown:
                moveDownAudio.Play(); break;

            case AudioTypes.rotate:
                rotateAudio.Play();   break;

            case AudioTypes.destroyTiles:
                destroyTilesAudio.Play();  break;

            case AudioTypes.lose:
                loseAudio.Play(); break;

            default:
                break;
        }

    }
}
