using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using Leap;
using Leap.Unity.Attributes;
using Leap.Unity;

public class CubeLetRoatation : MonoBehaviour {

    public GameObject LeapHandController;
    public float RotationSpeed = 10f;
    public float RotationScale = 1.0f;
    public Slider SensibilitySlider;

    //public GameObject Anchor;

    Quaternion handRotation;
    Quaternion lastHandRotation;

    Vector3 handRotationEuler;
    Vector3 lastHandRotationEuler;

    Vector3 initialInHandRotationEuler;
    Quaternion initialInHandRotation;
    Vector3 initialInCubeRotationEuler;
    Vector3 initialDeltaEuler;
    bool isInitial;

    float timeStamp;

    
    //Rigidbody rb;
    LeapServiceProvider leapServiceProvider;

	void Start () {
        leapServiceProvider = LeapHandController.GetComponent<LeapServiceProvider>();
        lastHandRotation = Quaternion.identity;
        isInitial = true;
        SensibilitySlider.onValueChanged.AddListener(RotationScaleChange);
	}

    void FixedUpdate()
    {
        Debug.Log(RotationScale);
        //handRotation = Quaternion.identity;
        if (leapServiceProvider.HasHand())
        {
            timeStamp += Time.deltaTime;
            if (timeStamp > 0.1f)
            {
                if (isInitial)
                {
                    initialInHandRotationEuler = leapServiceProvider.GetHandRotationEuler();
                    initialInHandRotation = leapServiceProvider.GetHandRoatatation();
                    initialInCubeRotationEuler = transform.eulerAngles;
                    initialDeltaEuler = initialInHandRotationEuler - initialInCubeRotationEuler;
                    isInitial = false;
                }
                else
                {
                    handRotation = leapServiceProvider.GetHandRoatatation();
                    handRotationEuler = leapServiceProvider.GetHandRotationEuler();

                    Vector3 deltaEuler = handRotationEuler - initialInHandRotationEuler;
                    Vector3 nowEuler = deltaEuler + initialInCubeRotationEuler;

                    Quaternion delta = Quaternion.Inverse(handRotation) * initialInHandRotation;

                    //transform.rotation = Quaternion.Euler(deltaEuler + initialInCubeRotationEuler);

                    // Good now
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.Euler(deltaEuler) * Quaternion.Euler(initialInCubeRotationEuler),
                        Time.deltaTime * RotationSpeed * RotationScale);

                    // New
                    //Quaternion.AngleAxis
                    //transform.eulerAngles = Quaternion.AngleAxis(90, Vector3.right) * transform.eulerAngles;

                }
            }
        }
        else
        {
            isInitial = true;
            timeStamp = 0f;
        }
    }

    public void RotationScaleChange(float newScale)
    {
        RotationScale = newScale;
    }

    
	
}
