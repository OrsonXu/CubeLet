using UnityEngine;
using System.Collections;
using Leap.Unity.Attributes;
using Leap.Unity;
using System.Threading;
using Leap;

public class followTransform : MonoBehaviour {

    public GameObject LeapHandController;

    public GameObject Anchor;

    Quaternion handRotation;
    Quaternion lastHandRotation;

    Vector3 handRotationEuler;
    Vector3 lastHandRotationEuler;

    Vector3 initialInHandRotationEuler;
    Quaternion initialInHandRotation;
    Vector3 initialInCubeRotationEuler;
    bool isInitial;

    float timeStamp;


    //Rigidbody rb;
    LeapServiceProvider leapServiceProvider;

    void Awake()
    {
        leapServiceProvider = LeapHandController.GetComponent<LeapServiceProvider>();
        lastHandRotation = Quaternion.identity;
        isInitial = true;
    }

    void FixedUpdate()
    {
        //transform = leapServiceProvider.
    }
}
