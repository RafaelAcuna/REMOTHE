using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoalCheck : MonoBehaviour
{
    public SoccerGame gameScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            gameScript.stopBall();
        }
    }
}
