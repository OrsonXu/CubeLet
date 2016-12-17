using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

public class LoadToScene : MonoBehaviour
{
    public int SceneIndex = 0;

    // Use this for initialization
    void Start()
    {

    }

    public void LoadToSceneIndex()
    {
        StartCoroutine(Fading());
        PlayerPrefs.SetInt("LastSceneIndex", SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Fading()
    {
        float time = GameObject.FindWithTag("Fade").GetComponent<SceneFadeInOut>().BeginFade(1);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneIndex);
    }
}
