using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerKeepCheck : MonoBehaviour
{
    public SoccerGame gameScript;
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            StartCoroutine(catchCoroutine());
        }
    }

    private IEnumerator catchCoroutine()
    {
        soundManager.playGloveCatch();
        gameScript.addPoints();
        gameScript.addKickTime(2.0f);

        yield return new WaitForSeconds(2);

        gameScript.stopBall();
    }
}
