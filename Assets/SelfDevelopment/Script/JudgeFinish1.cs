using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class JudgeFinish1 : MonoBehaviour {

    public GameObject CubeLet;
    public float range = 10f;
    public Text finishText;

    Transform transform;
    bool finished = false;
    Vector3[] finalDirection;
    float timeStamp;

    void Start()
    {
        transform = CubeLet.transform;
        finished = false;
        initFinalDirection();
        timeStamp = 0;
        finishText.text = "";
    }

    void initFinalDirection()
    {
        //finalDirection = new Vector3[8];
        //finalDirection[0] = new Vector3(1,1,1);
        //finalDirection[1] = new Vector3(1,1,-1);
        //finalDirection[2] = new Vector3(1, -1, 1);
        //finalDirection[3] = new Vector3(-1, 1, 1);
        //finalDirection[4] = new Vector3(1, -1, -1);
        //finalDirection[5] = new Vector3(-1, 1, -1);
        //finalDirection[6] = new Vector3(-1, -1, 1);
        //finalDirection[7] = new Vector3(-1, -1, -1);

        finalDirection = new Vector3[1];
        finalDirection[0] = new Vector3(0f,0f,0f);
    }

    void Update()
    {
        transform = CubeLet.transform;
        if (judge(transform))
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= 0.2f)
            {
                Debug.Log("Done");
                finish();
            }
            //else
            //{
            //    Debug.Log("");
            //}
        }
        else
        {
            timeStamp = 0;
        }
        
    }

    bool judge(Transform transform)
    {
        for (int i = 0; i < finalDirection.Length; i++)
        {
            if ((finalDirection[i].x - range <= transform.eulerAngles.x
                && transform.eulerAngles.x <= finalDirection[i].x + range)
                &&
                (finalDirection[i].y - range <= transform.eulerAngles.y
                && transform.eulerAngles.y <= finalDirection[i].y + range)
                &&
                (finalDirection[i].z - range <= transform.eulerAngles.z
                && transform.eulerAngles.z <= finalDirection[i].z + range))
            {
                return true;
            }
            //if (Vector3.Angle(finalDirection[i].normalized, Vector3.up) < 20f)
            //{
            //    return true;
            //}
        }
        return false;
    }

    public void finish()
    {
        finishText.text = "You are DONE!\nLoading Level 3...";
        Thread.Sleep(1000);
        SceneManager.LoadScene(4);
    }
}
