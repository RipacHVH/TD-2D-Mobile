using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
    public float CurrentTimeScale;
    private void Start()
    {
        //Time.timeScale = 1f;
        CurrentTimeScale = 1f;
    }
    public void SpeedUp()
    {
        if (Time.timeScale != 0f)
        {

            if (Time.timeScale == 1f)
            {
                Time.timeScale = 2f;
                gameObject.GetComponent<Image>().color = Color.red;
                CurrentTimeScale = 2f;
            }
            else
            {
                Time.timeScale = 1f;
                gameObject.GetComponent<Image>().color = Color.white;
                CurrentTimeScale = 1f;
            }
        }
    }
}
