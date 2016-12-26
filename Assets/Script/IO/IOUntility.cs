using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;
using System.IO;

public static class IOUntility
{
    public static void CreateFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public static void CreateFile(string filePath, string content)
    {
        StreamWriter writer;

        Debug.Log(filePath);
        string folder = filePath.Substring(0, filePath.LastIndexOf("//"));
        CreateFolder(folder);

        FileInfo file = new FileInfo(filePath);
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            file.Delete();
            writer = file.CreateText();
        }

        writer.Write(content);
        writer.Close();
        writer.Dispose();
    }

    public static bool isFileExists(string path)
    {
        FileInfo file = new FileInfo(path);
        return file.Exists;
    }

    public static void DeleteFile(string fileName)
    {
        if (!File.Exists(fileName)) return;
        File.Delete(fileName);
    }
}
