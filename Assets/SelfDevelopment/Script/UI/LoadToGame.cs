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
        SceneManager.LoadScene(LevelIndex + 1);
    }
}
