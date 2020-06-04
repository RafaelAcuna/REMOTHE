using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoeBoatCheck : MonoBehaviour
{
    public CanoeGame gameScript;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Obstacle":
                gameScript.loseLife();
                break;

            case "Fish":
                gameScript.addPoints(250);
                break;
            case "Life":
                gameScript.addPoints(500);
                gameScript.addLife();
                break;
            default:
                break;
        }

        Destroy(other.gameObject);
    }
}
