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


   [SerializeField] private AudioSource _clickAudio;
   [SerializeField] private AudioSource _moveDownAudio;
  [SerializeField]  private AudioSource _rotateAudio;
   [SerializeField] private AudioSource _destroyTilesAudio;
  [SerializeField]  private AudioSource _loseAudio;

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
                _clickAudio.Play(); break;

            case AudioTypes.moveDown:
                _moveDownAudio.Play(); break;

            case AudioTypes.rotate:
                _rotateAudio.Play();   break;

            case AudioTypes.destroyTiles:
                _destroyTilesAudio.Play();  break;

            case AudioTypes.lose:
                _loseAudio.Play(); break;

            default:
                break;
        }

    }
}
