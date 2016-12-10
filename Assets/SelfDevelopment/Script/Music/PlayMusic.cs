using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour {

    public AudioSource audioSource;
    public float fadeTime = 1f;
    public float normalVolume = 0.2f;
    private static PlayMusic instance = null;

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
        if (SceneManager.GetActiveScene().buildIndex <= 3)
        {
            // Fade Out
            if (audioSource.volume > 0)
                audioSource.volume -= normalVolume / fadeTime * Time.deltaTime;
        }
        else
        {
            // Not the first time entering the scene
            if (audioSource.volume < normalVolume)
            {
                audioSource.volume += normalVolume / fadeTime * Time.deltaTime;

            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
         //Fade in 
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = 0;
            audioSource.Play();
            audioSource.loop = true;
            //StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
        while (audioSource.volume < normalVolume)
        {
            audioSource.volume += normalVolume * Time.deltaTime;
            Debug.Log(audioSource.volume);
            yield return new WaitForSeconds(Time.deltaTime * fadeTime);
        }
    }

}
