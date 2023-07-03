using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnLoad : MonoBehaviour
{
    void Awake()
    {
        GameObject[] background = GameObject.FindGameObjectsWithTag("background");
        if (background.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
