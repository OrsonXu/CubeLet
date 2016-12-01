using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToLevelButton : MonoBehaviour {

    public int sceneLevel = 0;

    // Use this for initialization
    void Start()
    {

    }

    public void BackToLevelClicked()
    {
        SceneManager.LoadScene(sceneLevel);
    }
}
