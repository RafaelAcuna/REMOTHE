using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public GameObject ball, rA, rB, rC, rD, rE, rF;
    private Vector3 initialPosition;
    private Vector3[] referencePoints;
    private Rigidbody ballRigidbody;

    public float timeElapsed;
    private float kickTime;
    
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        kickTime = 5.0f;
        
        initialPosition = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);

        ballRigidbody = (Rigidbody)ball.GetComponent("Rigidbody");

        referencePoints = new Vector3[6];
        referencePoints[0] = rA.transform.position;
        referencePoints[1] = rB.transform.position;
        referencePoints[2] = rC.transform.position;
        referencePoints[3] = rD.transform.position;
        referencePoints[4] = rE.transform.position;
        referencePoints[5] = rF.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        kickTime -= Time.deltaTime;

        if(kickTime <= 0.0f)
        {
            kickBall();
            kickTime = 3.0f;
        }
    }

    private void kickBall()
    {
        Vector3 kickDirection = (referencePoints[Random.Range(0, 5)] - ball.transform.position).normalized;
        ballRigidbody.AddForce(kickDirection * (float)30.0, ForceMode.Impulse);
    }

    public void stopBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ball.transform.position = initialPosition;
    }
}
