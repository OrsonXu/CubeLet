using UnityEngine;
using System.Collections;

public class FindLightupMusic : MonoBehaviour {

    AudioSource audioSource;
    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("LightupMusic").GetComponent<AudioSource>();
    }
    public void FindAndPlay()
    {
        //AudioSource audioSource = GameObject.FindGameObjectWithTag("LightupMusic").GetComponent<AudioSource>();
        audioSource.Play();
    }
    public void FindAndSet(float value)
    {
        //AudioSource audioSource = GameObject.FindGameObjectWithTag("LightupMusic").GetComponent<AudioSource>();
        audioSource.volume = value;
    }
}
