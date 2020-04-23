using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public GameObject ball;
    private Vector3 initialPosition;
    private Rigidbody ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        ballRigidbody = (Rigidbody)ball.GetComponent("Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ballRigidbody.AddForce(initialPosition, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("m"))
        {
            ball.transform.position = initialPosition;
        }
    }
}
