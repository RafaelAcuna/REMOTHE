using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CanoeGame : MonoBehaviour
{
    public GameObject[] referencePoints;
    private Transform[] refTransforms;
    public GameObject[] spawnees;

    public Text pointCounter;
    public Text playerName;
    public GameObject life1, life2, life3;

    public SoundManager soundManager;
    public StaticSessionInfo sessionInfo;

    public float timeElapsed;
    private float spawnTime;

    private int lives = 3;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        spawnTime = 5.0f;

        int i = 0;
        refTransforms = new Transform[referencePoints.Length];
        foreach(GameObject refPoint in referencePoints)
        {
            refTransforms[i] = refPoint.transform;
            i++;
        }
        
        soundManager.playSplash();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0.0f)
        {
            spawnObject();
            spawnTime = 3.0f;
        }
    }

    private void spawnObject()
    {
        int randObj = UnityEngine.Random.Range(0, spawnees.Length);
        int randPosition = UnityEngine.Random.Range(0, refTransforms.Length);

        Instantiate(spawnees[randObj], refTransforms[randPosition].position, refTransforms[randPosition].rotation);
    }

    public void addPoints(int addedPoints)
    {
        soundManager.playCollect();

        points += addedPoints;
        pointCounter.text = points.ToString();
    }

    public void addLife()
    {
        if (lives == 2)
        {
            lives++;
            life1.SetActive(true);
        }
        else if (lives == 1)
        {
            lives++;
            life2.SetActive(true);
        }
    }

    public void loseLife()
    {
        lives--;
        if (lives == 2)
        {
            soundManager.playLifeLost();
            life1.SetActive(false);
        }
        else if (lives == 1)
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
        soundManager.playGameOver();

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("FinJuego");
    }
}
