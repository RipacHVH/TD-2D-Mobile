using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreMenu : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public int levelNumb;

    private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();

        switch (levelNumb)
        {
            case 1:
                scoreText.text = PlayerStats.lvlMaxScore1.ToString();
                break;
            case 2:
                scoreText.text = PlayerStats.lvlMaxScore2.ToString();
                break;
            case 3:
                scoreText.text = PlayerStats.lvlMaxScore3.ToString();
                break;
            case 4:
                scoreText.text = PlayerStats.lvlMaxScore4.ToString();
                break;
            case 5:
                scoreText.text = PlayerStats.lvlMaxScore5.ToString();
                break;
            case 6:
                scoreText.text = PlayerStats.lvlMaxScore6.ToString();
                break;
            case 7:
                scoreText.text = PlayerStats.lvlMaxScore7.ToString();
                break;
            case 8:
                scoreText.text = PlayerStats.lvlMaxScore8.ToString();
                break;
            case 9:
                scoreText.text = PlayerStats.lvlMaxScore9.ToString();
                break;
            case 10:
                scoreText.text = PlayerStats.lvlMaxScore10.ToString();
                break;
            case 11:
                scoreText.text = PlayerStats.lvlMaxScore11.ToString();
                break;
            case 12:
                scoreText.text = PlayerStats.lvlMaxScore12.ToString();
                break;
            case 13:
                scoreText.text = PlayerStats.lvlMaxScore13.ToString();
                break;
            case 14:
                scoreText.text = PlayerStats.lvlMaxScore14.ToString();
                break;
            case 15:
                scoreText.text = PlayerStats.lvlMaxScore15.ToString();
                break;
            case 16:
                scoreText.text = PlayerStats.lvlMaxScore16.ToString();
                break;
            case 17:
                scoreText.text = PlayerStats.lvlMaxScore17.ToString();
                break;
            case 18:
                scoreText.text = PlayerStats.lvlMaxScore18.ToString();
                break;

        }
        if (scoreText.text == "0")
        {
            scoreText.enabled = false;
        }
        else
        {
            scoreText.enabled = true;
        }
    }
}
