using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using Leap;
using Leap.Unity.Attributes;
using Leap.Unity;
using HighlightingSystem;

public class CubeLetRotation : MonoBehaviour {

    public float RotationSpeed = 10f;
    public float RotationScale = 1.0f;
    public Slider SensibilitySlider;

    float DetectionRange = 0.1f;

    GameObject leapHandController;
    LeapServiceProvider leapServiceProvider;

    /// <summary>
    /// Hand position and rotation
    /// </summary>
    Vector3 handPosition;
    Quaternion initialInHandRotation;
    Quaternion handRotation;
    Vector3 handRotationEuler;
    /// <summary>
    /// Cube rotation when the hand is detected by the leapmotion
    /// </summary>
    Vector3 initialInCubeRotationEuler;
    /// <summary>
    /// Initial frame flag
    /// </summary>
    bool isInitial;

    float dectionDist;
    float timeStamp;

    Highlighter highLighter;

	void Start () {
        leapHandController = GameObject.FindWithTag("LeapHandController");
        leapServiceProvider = leapHandController.GetComponent<LeapServiceProvider>();
        isInitial = true;
        SensibilitySlider.onValueChanged.AddListener(RotationScaleChange);
        highLighter = GetComponent<Highlighter>();
        if (highLighter == null)
        {
            highLighter = gameObject.AddComponent<Highlighter>();
        }
        dectionDist = DetectionRange * DetectionRange;
	}

    void FixedUpdate()
    {
        //handRotation = Quaternion.identity;
        if (leapServiceProvider.HasHand())
        {
            // Make sure the hand is in the range
            handPosition = leapServiceProvider.GetHandPosition();
            // Only x and z are taken into consideration
            float dist = handPosition.x * handPosition.x + handPosition.z * handPosition.z;
            if (dist > dectionDist)
            {
                highLighter.ConstantOff();
                return;
            }
            timeStamp += Time.deltaTime;
            if (timeStamp > 0.1f)
            {
                highLighter.ConstantOn(Color.green);
                if (isInitial)
                {
                    initialInHandRotation = leapServiceProvider.GetHandRoatatation();
                    initialInCubeRotationEuler = transform.eulerAngles;
                    isInitial = false;
                }
                else
                {
                    
                    handRotation = leapServiceProvider.GetHandRoatatation();
                    handRotationEuler = leapServiceProvider.GetHandRotationEuler();

                    //Vector3 deltaEuler = handRotationEuler - initialInHandRotationEuler;

                    Quaternion tmp = handRotation * Quaternion.Inverse(initialInHandRotation);

                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        tmp * Quaternion.Euler(initialInCubeRotationEuler),
                        Time.deltaTime * RotationSpeed * RotationScale);

                    //Vector3 handpos = leapServiceProvider.GetHandPosition();
                    ////float dist = Vector3.Distance(handpos, gameObject.transform.position);
                    //float dist = Vector3.Distance(handpos, new Vector3(0,0,0));

                    //Debug.Log(dist);

                }
            }
        }
        else
        {
            highLighter.ConstantOff();
            isInitial = true;
            timeStamp = 0f;
        }
    }

    public void RotationScaleChange(float newScale)
    {
        RotationScale = newScale;
        PlayerPrefs.SetFloat("SenibilityVolume", newScale);
    }

    
	
}
