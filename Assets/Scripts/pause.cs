using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public Canvas PauseCanvas;
    public GameObject OptionsMenu;
    TimeScale tsScript;
    private void Start()
    {
        tsScript = GameObject.Find("TimeScale").GetComponent<TimeScale>();
    }
    public void Pause()
    {
        if (Time.timeScale >= 1f)
        {
            Time.timeScale = 0f;
            PauseCanvas.enabled = true;
        }
        else
        {
            Time.timeScale = tsScript.CurrentTimeScale;
            PauseCanvas.enabled = false;
        }
    }
    public void Options()
    {
        Time.timeScale = 0f;
        Instantiate(OptionsMenu, OptionsMenu.transform.position, OptionsMenu.transform.rotation);
    }    
    public void Resume()
    {
        Time.timeScale = tsScript.CurrentTimeScale;
        Destroy(OptionsMenu);
    }
}
