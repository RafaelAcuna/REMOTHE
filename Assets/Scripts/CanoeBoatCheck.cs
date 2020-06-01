using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoeBoatCheck : MonoBehaviour
{
    public CanoeGame gameScript;

    private Vector3 targetPosition;
    private float targetDistance;

    private float speed = 2;

    private void Update()
    {
        if (Input.GetKey("a") && transform.localPosition.x > -8.0f)
        {
            transform.Rotate(new Vector3(0, 0, -0.1f));
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey("d") && transform.localPosition.x < 8.0f)
        {
            transform.Rotate(new Vector3(0, 0, 0.1f));
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

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
