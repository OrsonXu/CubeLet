using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.UI;
using Leap;
using Leap.Unity.Attributes;
using Leap.Unity;

public class CubeLetRotation : MonoBehaviour {

    public float RotationSpeed = 10f;
    public float RotationScale = 1.0f;
    public Slider SensibilitySlider;

    GameObject LeapHandController;

    Quaternion handRotation;
    Quaternion lastHandRotation;

    Vector3 handRotationEuler;
    Vector3 lastHandRotationEuler;

    Vector3 initialInHandRotationEuler;
    Quaternion initialInHandRotation;
    Vector3 initialInCubeRotationEuler;
    Vector3 initialHandDirection;
    bool isInitial;

    float timeStamp;

    LeapServiceProvider leapServiceProvider;

	void Start () {
        LeapHandController = GameObject.FindWithTag("LeapHandController");
        leapServiceProvider = LeapHandController.GetComponent<LeapServiceProvider>();
        //lastHandRotation = Quaternion.identity;
        isInitial = true;
        SensibilitySlider.onValueChanged.AddListener(RotationScaleChange);
	}

    void FixedUpdate()
    {
        //handRotation = Quaternion.identity;
        if (leapServiceProvider.HasHand())
        {
            //Debug.Log(leapServiceProvider.GetHandRoatatation());
            timeStamp += Time.deltaTime;
            if (timeStamp > 0.1f)
            {
                if (isInitial)
                {
                    initialInHandRotationEuler = leapServiceProvider.GetHandRotationEuler();
                    initialInHandRotation = leapServiceProvider.GetHandRoatatation();
                    initialInCubeRotationEuler = transform.eulerAngles;
                    initialHandDirection = leapServiceProvider.GetHandDirection();
                    isInitial = false;
                }
                else
                {
                    
                    handRotation = leapServiceProvider.GetHandRoatatation();
                    handRotationEuler = leapServiceProvider.GetHandRotationEuler();

                    //Vector3 deltaEuler = handRotationEuler - initialInHandRotationEuler;

                    //this is wrong!
                    Quaternion deltaEuler = Quaternion.FromToRotation(initialHandDirection, leapServiceProvider.GetHandDirection());

                    // Another test
                    //Quaternion tmp = Quaternion.RotateTowards(initialInHandRotation, handRotation, 1000f);
                    Quaternion tmp = handRotation * Quaternion.Inverse(initialInHandRotation);


                    //Debug.Log(tmp.eulerAngles);
                    //if (tmp.eulerAngles.x < 10)
                    //{
                    //    tmp.SetEulerAngles(360 - tmp.eulerAngles.x, tmp.eulerAngles.y, tmp.eulerAngles.z); 
                    //}
                    //if (tmp.eulerAngles.y < 10)
                    //{
                    //    tmp.SetEulerAngles(tmp.eulerAngles.x, 360 - tmp.eulerAngles.y, tmp.eulerAngles.z);
                    //}
                    //if (tmp.eulerAngles.z < 10)
                    //{
                    //    tmp.SetEulerAngles(tmp.eulerAngles.x, tmp.eulerAngles.y, 360 - tmp.eulerAngles.z);
                    //}

                    //deltaEuler = Quaternion.LookRotation(MainCameraTransform.eulerAngles) * deltaEuler;
                    //deltaEuler = Quaternion.FromToRotation(initialHandDirection, Vector3.forward) * deltaEuler;

                    // Good now
                    //transform.rotation = Quaternion.Slerp(transform.rotation,
                    //    Quaternion.Euler(deltaEuler) * Quaternion.Euler(initialInCubeRotationEuler),
                    //    Time.deltaTime * RotationSpeed * RotationScale);

                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        tmp * Quaternion.Euler(initialInCubeRotationEuler),
                        Time.deltaTime * RotationSpeed * RotationScale);

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
        PlayerPrefs.SetFloat("SenibilityVolume", newScale);
    }

    
	
}
