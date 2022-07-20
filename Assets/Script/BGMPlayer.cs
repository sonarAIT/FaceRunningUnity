using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    
    AudioSource audioSource;
    public AudioClip[] BGM;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayBGM(int idx) {
        audioSource.Stop();
        audioSource.clip = BGM[idx];
        audioSource.Play();
    }

    public void PauseBGM(bool isPause) {
        if(isPause) {
            audioSource.Pause();
        } else {
            audioSource.UnPause();
        }
        
    }

    public void StopBGM() {
        audioSource.Stop();
    }

    public void SetLoop(bool isLoop) {
        audioSource.loop = isLoop;
    }
}
