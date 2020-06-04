using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class YogaGame : MonoBehaviour
{
    public Text playerName;
    public Text timeDisplay;

    public SoundManager soundManager;
    public YogaKinectManager kinectManager;
    public YogaVideoManager videoManager;
    public StaticSessionInfo sessionInfo;

    public GameObject pausePanel;

    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pauseGame();
        }

        timeElapsed += Time.deltaTime;

        string minutes = Math.Floor(timeElapsed / 60.0f).ToString();
        int seconds = (int)(timeElapsed % 60.0f);
        if(seconds < 10)
            timeDisplay.text = minutes + ":0" + seconds;
        else
            timeDisplay.text = minutes + ":" + seconds;

        if (timeElapsed > 300.0f)
        {
            writeSessionInfo();
            StartCoroutine(endGame());
        }
    }

    private void writeSessionInfo()
    {
        sessionInfo.updateInfo(0, timeElapsed);
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
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("FinJuego");
    }

    private void pauseGame()
    {
        Time.timeScale = 0;
        videoManager.pauseVideo();
        pausePanel.SetActive(true);
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        videoManager.resumeVideo();
        pausePanel.SetActive(false);
    }

    public void pauseEndGame()
    {
        Time.timeScale = 1;
        kinectManager.destroyInstance();

        SceneManager.LoadScene("MenuPrincipal");
    }
}
