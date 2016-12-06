using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadToHome : MonoBehaviour
{
    public int sceneHome = 0;

    // Use this for initialization
    void Start()
    {

    }

    public void LoadToHomeScene()
    {
        SceneManager.LoadScene(sceneHome);
    }
}
