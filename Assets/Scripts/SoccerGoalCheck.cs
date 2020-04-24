using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoalCheck : MonoBehaviour
{
    public SoccerGame gameScript;
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            soundManager.playNetHit();
            gameScript.stopBall();
            gameScript.loseLife();
        }
    }
}
