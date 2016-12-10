using UnityEngine;
using System.Collections;

public class FindSelectionMusic : MonoBehaviour {

    AudioSource audioSource;
    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SelectionMusic").GetComponent<AudioSource>();
    }
    public void FindAndPlay()
    {
        //AudioSource audioSource = GameObject.FindGameObjectWithTag("SelectionMusic").GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void FindAndSet(float value)
    {
        //AudioSource audioSource = GameObject.FindGameObjectWithTag("SelectionMusic").GetComponent<AudioSource>();
        audioSource.volume = value;
    }

}
