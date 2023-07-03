using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockMore : MonoBehaviour
{
    public GameObject Screen1, Screen2;
    private void Start()
    {
        if (PlayerStats.Stars >= 17)
        {
            Destroy(Screen1);
        }
        if (PlayerStats.Stars >= 34)
        {
            Destroy(Screen2);
        }
    }
}
