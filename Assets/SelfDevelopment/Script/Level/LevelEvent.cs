using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class LevelEvent : MonoBehaviour {

    public Level level;

    public void OnClick()
    {
        if (!level.Locked)
        {
            SceneManager.LoadScene(Convert.ToInt32(level.ID) + 3);
            Debug.Log("Level now : " + level.Name);
        }
        else
        {
            Debug.Log("Sorry, this level hasn't been unlocked!");
        }

    }
}
