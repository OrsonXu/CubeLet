using UnityEngine;
using System.Collections;
using Leap.Unity.Attributes;
using Leap.Unity;
using System.Threading;
using Leap;

public class CubeRoatationTest : MonoBehaviour {


    Quaternion handRotation;
    Quaternion lastHandRotation;

    Vector3 handRotationEuler;
    Vector3 lastHandRotationEuler;

    float timeStamp;

    public GameObject LeapHandController;
    //Rigidbody rb;
    LeapServiceProvider leapServiceProvider;

	void Start () {
        leapServiceProvider = LeapHandController.GetComponent<LeapServiceProvider>();
        lastHandRotation = Quaternion.identity;
	}

    void Update()
    {
        //handRotation = Quaternion.identity;
        if (leapServiceProvider.HasHand())
        {
            timeStamp += Time.deltaTime;
            if (timeStamp > 0.1f)
            {
                handRotation = leapServiceProvider.GetHandRoatatation();
                handRotationEuler = leapServiceProvider.GetHandRotationEuler();

                //float x = transform.rotation.x + handRotation.x - lastHandRotation.x;
                //float y = transform.rotation.y + handRotation.y - lastHandRotation.y;
                //float z = transform.rotation.z + handRotation.z - lastHandRotation.z;
                //float w = transform.rotation.z + handRotation.w - lastHandRotation.w;

                //Quaternion deltaHandRotation = new Quaternion(x, y, z, w);

                Vector3 deltaEular = handRotationEuler - lastHandRotationEuler;

                Quaternion relative = Quaternion.Inverse(lastHandRotation) * handRotation;
                
                //Debug.Log(deltaEular.ToString());

                //transform.rotation = Quaternion.Slerp(transform.rotation, handRotation, Time.deltaTime * 10f);
                //transform.rotation = Quaternion.Slerp(transform.rotation, deltaHandRotation, Time.deltaTime * 10f);

                //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + deltaEular, Time.deltaTime * 10f);
                transform.rotation = Quaternion.Slerp(transform.rotation, handRotation, Time.deltaTime * 10f);

                lastHandRotation = handRotation;
                lastHandRotationEuler = handRotationEuler;
                
            }
        }
        else
        {
            timeStamp = 0f;
        }
    }
	
}
