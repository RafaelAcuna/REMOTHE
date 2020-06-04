using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SoccerGame : MonoBehaviour
{
    public GameObject ball, rA, rB, rC, rD, rE, rF;
    private Vector3 initialPosition;
    private Vector3[] referencePoints;
    private Rigidbody ballRigidbody;

    public Text pointCounter;
    public Text playerName;
    public GameObject life1, life2, life3;

    public SoundManager soundManager;
    public SoccerKinectManager kinectManager;
    public StaticSessionInfo sessionInfo;

    public float timeElapsed;
    private float kickTime;

    private int lives = 3;
    private int points = 0;

    public GameObject pausePanel;
    
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
        if(Input.GetKeyDown("escape"))
        {
            pauseGame();
        }

        timeElapsed += Time.deltaTime;
        kickTime -= Time.deltaTime;

        if(kickTime <= 0.0f)
        {
            soundManager.playBallKick();
            kickBall();
            kickTime = 3.0f;
        }
    }

    private void kickBall()
    {
        Vector3 kickDirection = (referencePoints[UnityEngine.Random.Range(0, 5)] - ball.transform.position).normalized;
        ballRigidbody.AddForce(kickDirection * (float)30.0, ForceMode.Impulse);
    }

    public void stopBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ball.transform.position = initialPosition;
    }

    public void addKickTime(float time)
    {
        kickTime += time;
    }

    public void addPoints()
    {
        soundManager.playCelebration();
        points += 250;
        pointCounter.text = points.ToString();
    }

    public void loseLife()
    {
        lives--;
        if(lives == 2)
        {
            soundManager.playLifeLost();
            life1.SetActive(false);
        }
        else if(lives == 1)
        {
            soundManager.playLifeLost();
            life2.SetActive(false);
        }
        else
        {
            life3.SetActive(false);
            writeSessionInfo();
            StartCoroutine(endGame());
        }
    }

    private void writeSessionInfo()
    {
        sessionInfo.updateInfo(points, timeElapsed);
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/REMOTHE/" + playerName.text + ".txt";

        if (File.Exists(path))
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(DateTime.Now.ToString().Split(' ')[0] + "-" + timeElapsed);
            sw.Close();
        }
    }

    private IEnumerator endGame()
    {
        kinectManager.destroyInstance();
        soundManager.playGameOver();

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("FinJuego");
    }

    private void pauseGame()
    {
        Time.timeScale = 0;

        pausePanel.SetActive(true);
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }

    public void pauseEndGame()
    {
        Time.timeScale = 1;
        kinectManager.destroyInstance();

        SceneManager.LoadScene("MenuPrincipal");
    }
}
