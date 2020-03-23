using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDateTime : MonoBehaviour
{
    public Text dateTimeDisplay;
    private DateTime dateTime;

    // Start is called before the first frame update
    void Start()
    {
        dateTime = DateTime.Now;
        dateTimeDisplay.text = dateTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        dateTime = DateTime.Now;
        dateTimeDisplay.text = dateTime.ToString();
    }
}
