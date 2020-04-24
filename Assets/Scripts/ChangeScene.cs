using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void doChangeScene(string sceneName)
    {
        StartCoroutine(changeScene(sceneName));
    }

    private IEnumerator changeScene(string sceneName)
    {
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
