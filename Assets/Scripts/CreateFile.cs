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
        string path = Application.dataPath + "/" + playerName.text + ".txt";

        if(!File.Exists(path))
        {
            File.Create(path);
        }
    }
}