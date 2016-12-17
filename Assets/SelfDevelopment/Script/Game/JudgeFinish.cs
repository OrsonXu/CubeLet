using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class JudgeFinish : MonoBehaviour {

    public float range = 5f;
    public Text finishText;
    public GameObject[] points;

    GameObject CubeLet;
    int IndexID;
    Transform transform;
    bool finished = false;
    Vector3[] finalDirection;
    float timeStamp;

    void Start()
    {
        CubeLet = this.gameObject;
        IndexID = SceneManager.GetActiveScene().buildIndex - 3;
        transform = CubeLet.transform;
        finished = false;
        initFinalDirection();
        timeStamp = 0;
        finishText.text = "";
    }

    void initFinalDirection()
    {
        finalDirection = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            finalDirection[i] = points[i].transform.position - CubeLet.transform.position;
        }
    }

    void Update()
    {
        transform = CubeLet.transform;
        for (int i = 0; i < finalDirection.Length; i++)
        {
            finalDirection[i] = points[i].transform.position - CubeLet.transform.position;
        }

        //Debug.Log(finalDirection[0].ToString());
        if (judge(transform))
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= 0.2f)
            {
                //Debug.Log("Done");
                finish();
            }
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
            if (Vector3.Angle(finalDirection[i].normalized, Vector3.up) < range
                || Vector3.Angle(finalDirection[i].normalized, Vector3.down) < range)
            {
                return true;
            }
        }
        return false;
    }

    public void finish()
    {
        finishText.text = "You are DONE!\nLoading Level " + (IndexID + 1).ToString() + "...";
        StartCoroutine(Fading());
        LevelSystem.SetLevels(("level" + (IndexID + 1).ToString()), false);
    }

    IEnumerator Fading()
    {
        float time = GameObject.FindWithTag("Fade").GetComponent<SceneFadeInOut>().BeginFade(1);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
