using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadToLevelButton : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadToLevelScene()
    {
        SceneManager.LoadScene(1);
    }
}
