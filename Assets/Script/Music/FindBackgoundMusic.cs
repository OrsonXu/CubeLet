using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FindBackgoundMusic : MonoBehaviour {

    AudioSource audioSource;
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
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
        //Debug.Log("Background volume : " + value.ToString());
        PlayerPrefs.SetFloat("MusicVolume", value);
    }


}
