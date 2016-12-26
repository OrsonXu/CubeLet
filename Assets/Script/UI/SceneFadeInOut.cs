using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFadeInOut : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeTime = 0.8f;

    int drawDepth = -1000;
    float alpha = 1.0f;
    int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir / fadeTime * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
    /// <summary>
    /// The function for begin fading
    /// </summary>
    /// <param name="dir">1 for fading in, -1 for fading out</param>
    public float BeginFade(int dir)
    {
        fadeDir = dir;
        return fadeTime;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        BeginFade(-1);
    }
}
