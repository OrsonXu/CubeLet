using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml.Serialization;

public class LevelManager : MonoBehaviour {

    private List<Level> levelList;
    void Awake()
    {
        levelList = LevelSystem.LoadLevels();
        foreach (Level l in levelList)
        {
            GameObject prefab = Instantiate((Resources.Load("Level") as GameObject));

            DataBind(prefab, l);

            prefab.transform.SetParent(GameObject.Find("ChooseLevelScrollList/List/Image").transform);
            //prefab.transform.localPosition = new Vector3(0, 0, 0);
            prefab.transform.localScale = new Vector3(1, 1, 1);

            prefab.GetComponent<LevelEvent>().level = l;
            prefab.name = l.Name;
        }
    }

    void DataBind(GameObject go, Level level)
    {
        go.transform.Find("LevelName").GetComponent<Text>().text = level.Name;
        go.transform.Find("LevelName").GetComponent<Text>().transform.localPosition = new Vector3(0, 0, 0);
        Texture2D tex2D;
        if (level.Locked)
        {
            tex2D = Resources.Load("lock") as Texture2D;
        }
        else
        {
            tex2D = Resources.Load(level.Name) as Texture2D;
            if (tex2D == null)
            {
                tex2D = Resources.Load("question") as Texture2D;
            }
        }
        Sprite sprite = Sprite.Create(tex2D, new Rect(0, 0, tex2D.width, tex2D.height), new Vector2(0.5F, 0.5F));
        go.transform.GetComponent<Image>().sprite = sprite;
    }
}
