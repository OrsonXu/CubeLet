using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Leap;

public class CUbeLetRotation : MonoBehaviour {

    public Controller LeapHandController;
    public float RotationSpeed = 10f;
    public float RotationScale = 1.0f;
    public Slider SensibilitySlider;

    List<Hand> hands;

    bool isInitial;

	// Use this for initialization
	void Start () {
        isInitial = true;
        SensibilitySlider.onValueChanged.AddListener(RotationScaleChange);
	}
	
	// Update is called once per frame
	void Update () {
        Frame frame = LeapHandController.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            hands = frame.Hands;
            Hand firstHand = hands[0];
        }
	}

    public void RotationScaleChange(float newScale)
    {
        RotationScale = newScale;
    }
}
