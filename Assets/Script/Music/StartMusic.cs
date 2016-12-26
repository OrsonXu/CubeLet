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
        // Singelton mode
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


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(PlayerPrefs.GetInt("LastSceneIndex"));
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            audioSource.volume = 0;
        }
        else if (PlayerPrefs.GetInt("LastSceneIndex") > 3)
        {
            //If back to the first four scenes, new an audioSource
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = normalVolume;
            audioSource.Play();
            audioSource.loop = true;
        }
    }

}
