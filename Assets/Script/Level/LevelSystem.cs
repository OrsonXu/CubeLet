using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public static class LevelSystem 
{

    private static string filePath = Application.dataPath + "/Resources/levels.xml";
    public static List<Level> LoadLevels()
    {

        XmlDocument xmlDoc = new XmlDocument();

        //if (!IOUntility.isFileExists (filePath)) {
        //    xmlDoc.LoadXml(((TextAsset)Resources.Load ("levels")).text);
        //    IOUntility.CreateFile (filePath, xmlDoc.InnerXml);
        //} else {
        xmlDoc.Load(filePath);
        //}
        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");
        
        List<Level> levels = new List<Level>();
        foreach (XmlElement xe in levelsNode) 
        {
            Level l = new Level();
            l.ID=xe.GetAttribute("id");
            l.Name=xe.GetAttribute("name");
            
            if(xe.GetAttribute("locked")=="1"){
                l.Locked=true;
            }else{
                l.Locked=false;
            }

            levels.Add(l);
        }

        return levels;
    }

    public static void SetLevels(string name,bool locked)
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.Load(filePath);
        XmlElement root = xmlDoc.DocumentElement;
        XmlNodeList levelsNode = root.SelectNodes("/levels/level");
        foreach (XmlElement xe in levelsNode) 
        {
            if(xe.GetAttribute("name")==name)
            {
                if(locked){
                    xe.SetAttribute("locked","1");
                }else{
                    xe.SetAttribute("locked","0");
                }
            }
        }
        xmlDoc.Save(filePath);
    }
}

