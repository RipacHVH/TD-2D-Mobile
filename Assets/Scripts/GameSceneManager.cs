using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject selectDifficulty;
    public void GoToMaps()
    {
        StartCoroutine(LoadAsynchronously("LevelsMenu"));
        //SceneManager.LoadScene("LevelsMenu");
        Time.timeScale = 1f;
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously("Main Menu"));
        //SceneManager.LoadScene("Main Menu");

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void GoToTheMap(string levelName)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously(levelName));

    }
    IEnumerator LoadAsynchronously(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
