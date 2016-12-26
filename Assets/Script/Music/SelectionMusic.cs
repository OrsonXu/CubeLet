using UnityEngine;
using System.Collections;

public class SelectionMusic : MonoBehaviour {

    public AudioSource audioSource;
    private static SelectionMusic instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    
}
