using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateSessionTime : MonoBehaviour
{
    public StaticSessionInfo sessionInfo;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        TimeSpan t = TimeSpan.FromSeconds(sessionInfo.getTimeElapsed());

        string answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds);

        timeText.text += " " + answer;
    }
}
