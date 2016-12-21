using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{

    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        //print("Pause function usable");
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else 
            Application.Quit();
#endif
    }

    public void SetVolume()
    {
        Slider slider = transform.FindChild("MusicVolumnSlider").GetComponent<Slider>();
        slider.value = 0.2f;
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        Slider slider2 = transform.FindChild("SensibilitySlider").GetComponent<Slider>();
        slider2.value = 1;
        slider2.value = PlayerPrefs.GetFloat("SenibilityVolume");
    }

}