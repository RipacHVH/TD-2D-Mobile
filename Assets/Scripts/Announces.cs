using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announces : MonoBehaviour
{
    public int lvl;
    public GameObject Ann;
    private void Awake()
    {
        switch (lvl)
        {
            case 2:
                if (!PlayerStats.Ann2)
                {
                    Time.timeScale = 0f;
                    Ann.SetActive(true);
                    PlayerStats.Ann2 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 3:
                if (!PlayerStats.Ann3)
                {
                    Time.timeScale = 0f;
                    Ann.SetActive(true);
                    PlayerStats.Ann3 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 4:
                if (!PlayerStats.Ann4)
                {
                    Time.timeScale = 0f;
                    Ann.SetActive(true);
                    PlayerStats.Ann4 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 5:
                if (!PlayerStats.Ann5)
                {
                    Time.timeScale = 0f;
                    Ann.SetActive(true);
                    PlayerStats.Ann5 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 7:
                if (!PlayerStats.Ann7)
                {
                    Time.timeScale = 0f;
                    Ann.SetActive(true);
                    PlayerStats.Ann7 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 13:
                if (!PlayerStats.Ann13)
                {
                    Time.timeScale = 0f;
                    Ann.SetActive(true);
                    PlayerStats.Ann13 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
        }
                
    }
    public void HideAnn()
    {
        Time.timeScale = 1f;
        Ann.SetActive(false);
        switch (lvl)
        {
            case 2:
                if (!PlayerStats.Ann2)
                {
                    PlayerStats.Ann2 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 3:
                if (!PlayerStats.Ann3)
                {
                    PlayerStats.Ann3 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 4:
                if (!PlayerStats.Ann4)
                {
                    PlayerStats.Ann4 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 5:
                if (!PlayerStats.Ann5)
                {
                    PlayerStats.Ann5 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 7:
                if (!PlayerStats.Ann7)
                {
                    PlayerStats.Ann7 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
            case 13:
                if (!PlayerStats.Ann13)
                {
                    PlayerStats.Ann13 = true;
                    GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
                }
                break;
        }
    }

}
