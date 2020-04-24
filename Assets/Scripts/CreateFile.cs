using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
    
public class CreateFile : MonoBehaviour
{
    public Text playerName;

    void Start()
    {
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/REMOTHE");

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/REMOTHE/" + playerName.text + ".txt";

        if(!File.Exists(path))
        {
            File.Create(path);
        }
    }
}