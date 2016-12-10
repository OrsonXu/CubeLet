using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMusic : MonoBehaviour {

    public AudioSource audioSource;
    public float fadeTime = 1f;
    public float normalVolume = 0.2f;
    private static StartMusic instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            if (audioSource.volume > 0)
                audioSource.volume -= normalVolume * fadeTime * Time.deltaTime;
        }
        else
        {
            // If back to the first four scenes, new an audioSource
            if (audioSource.volume < normalVolume)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.volume = normalVolume;
                audioSource.Play();
                audioSource.loop = true;
            }
        }
    }

}
