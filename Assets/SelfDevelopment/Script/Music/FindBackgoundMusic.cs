using UnityEngine;
using System.Collections;

public class FindBackgoundMusic : MonoBehaviour {

    AudioSource audioSource;
    void Awake()
    {
        if (GameObject.Find("BackgroundMusicStartMain"))
        {
            audioSource = GameObject.Find("BackgroundMusicStartMain").GetComponent<AudioSource>();
        }
        else
        {
            audioSource = GameObject.Find("BackgroundMusicPlay").GetComponent<AudioSource>();
        }
    }
    public void FindAndPlay()
    {
        //AudioSource audioSource = GameObject.Find("BackgroundMusicStartMain").GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void FindAndSet(float value)
    {
        //AudioSource audioSource = GameObject.Find("BackgroundMusicStartMain").GetComponent<AudioSource>();
        audioSource.volume = value;
    }


}
