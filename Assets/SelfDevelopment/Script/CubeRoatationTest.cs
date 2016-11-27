using UnityEngine;
using System.Collections;
using Leap.Unity.Attributes;
using Leap.Unity;
using System.Threading;
using Leap;

public class CubeRoatationTest : MonoBehaviour {

    public GameObject LeapHandController;
    public float RotationSpeed = 0.2f;

    Quaternion handRotation;
    Quaternion lastHandRotation;

    Vector3 handRotationEuler;
    Vector3 lastHandRotationEuler;

    Vector3 initialInHandRotationEuler;
    Vector3 initialInCubeRotationEuler;
    bool isInitial;

    float timeStamp;

    
    //Rigidbody rb;
    LeapServiceProvider leapServiceProvider;

	void Awake () {
        leapServiceProvider = LeapHandController.GetComponent<LeapServiceProvider>();
        lastHandRotation = Quaternion.identity;
        isInitial = true;
	}

    void FixedUpdate()
    {
        //handRotation = Quaternion.identity;
        if (leapServiceProvider.HasHand())
        {
            timeStamp += Time.deltaTime;
            if (timeStamp > 0.1f)
            {
                if (isInitial)
                {
                    initialInHandRotationEuler = leapServiceProvider.GetHandRotationEuler();
                    initialInCubeRotationEuler = transform.eulerAngles;
                    isInitial = false;
                }
                else
                {
                    handRotation = leapServiceProvider.GetHandRoatatation();
                    handRotationEuler = leapServiceProvider.GetHandRotationEuler();

                    //Debug.Log(initialInHandRotationEuler.ToString());

                    //Vector3 deltaEular = handRotationEuler - lastHandRotationEuler;
                    Vector3 deltaEuler = handRotationEuler - initialInHandRotationEuler;
                    Vector3 nowEuler = deltaEuler + initialInCubeRotationEuler;
                    Debug.Log(nowEuler.ToString());
                    //transform.rotation = Quaternion.Slerp(transform.rotation, handRotation, Time.deltaTime * 10f);

                    //Vector3 newEuler = Vector3.Slerp(transform.eulerAngles, nowEuler, RotationSpeed * Time.deltaTime);
                    //transform.eulerAngles = newEuler;

                    transform.eulerAngles = deltaEuler + initialInCubeRotationEuler;

                    //lastHandRotation = handRotation;
                    //lastHandRotationEuler = handRotationEuler;
                }
            }
        }
        else
        {
            isInitial = true;
            timeStamp = 0f;
        }
    }

    
	
}
