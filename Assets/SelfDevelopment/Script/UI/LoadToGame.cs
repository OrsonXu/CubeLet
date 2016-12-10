using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadToGame : MonoBehaviour {

    public int LevelIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadToGameScene()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        float time = GameObject.FindWithTag("Fade").GetComponent<SceneFadeInOut>().BeginFade(1);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(LevelIndex + 3);
    }
}
