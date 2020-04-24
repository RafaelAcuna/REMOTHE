using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticSessionInfo : MonoBehaviour
{
    static public int points = 0;
    static public float timeElapsed = 0;
    
    public void updateInfo(int newPoints, float newTime)
    {
        points = newPoints;
        timeElapsed = newTime;
    }

    public int getPoints()
    {
        return points;
    }

    public float getTimeElapsed()
    {
        return timeElapsed;
    }
}
