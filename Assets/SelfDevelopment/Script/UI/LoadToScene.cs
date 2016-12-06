using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadToScene : MonoBehaviour
{
    public int SceneIndex = 0;

    // Use this for initialization
    void Start()
    {

    }

    public void LoadToSceneIndex()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
