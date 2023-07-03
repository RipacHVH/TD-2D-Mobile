using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int scoreAmount;
    protected float Timer;
    public TextMeshProUGUI scoreText;
    public int DelayAmount = 1;
    public bool ended;
    Enemy enemySpawnScript;
    private void Start()
    {
        enemySpawnScript = GameObject.Find("Enemy Spawner").GetComponent<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount && !ended)
        {
            Timer = 0f;
            scoreAmount++;
            scoreText.text = scoreAmount.ToString();
        }
        if (ended)
        {
            CheckMaxScore();

        }
    }

    void CheckMaxScore()
    {
        switch (enemySpawnScript.Level)
        {
            case 1:
                if (PlayerStats.lvlMaxScore1 < scoreAmount)
                    PlayerStats.lvlMaxScore1 = scoreAmount;
                break;
            case 2:
                if (PlayerStats.lvlMaxScore2 < scoreAmount)
                    PlayerStats.lvlMaxScore2 = scoreAmount;
                break;
            case 3:
                if (PlayerStats.lvlMaxScore3 < scoreAmount)
                    PlayerStats.lvlMaxScore3 = scoreAmount;
                break;
            case 4:
                if (PlayerStats.lvlMaxScore4 < scoreAmount)
                    PlayerStats.lvlMaxScore4 = scoreAmount;
                break;
            case 5:
                if (PlayerStats.lvlMaxScore5 < scoreAmount)
                    PlayerStats.lvlMaxScore5 = scoreAmount;
                break;
            case 6:
                if (PlayerStats.lvlMaxScore6 < scoreAmount)
                    PlayerStats.lvlMaxScore6 = scoreAmount;
                break;
            case 7:
                if (PlayerStats.lvlMaxScore7 < scoreAmount)
                    PlayerStats.lvlMaxScore7 = scoreAmount;
                break;
            case 8:
                if (PlayerStats.lvlMaxScore8 < scoreAmount)
                    PlayerStats.lvlMaxScore8 = scoreAmount;
                break;
            case 9:
                if (PlayerStats.lvlMaxScore9 < scoreAmount)
                    PlayerStats.lvlMaxScore9 = scoreAmount;
                break;
            case 10:
                if (PlayerStats.lvlMaxScore10 < scoreAmount)
                    PlayerStats.lvlMaxScore10 = scoreAmount;
                break;
            case 11:
                if (PlayerStats.lvlMaxScore11 < scoreAmount)
                    PlayerStats.lvlMaxScore11 = scoreAmount;
                break;
            case 12:
                if (PlayerStats.lvlMaxScore12 < scoreAmount)
                    PlayerStats.lvlMaxScore12 = scoreAmount;
                break;
            case 13:
                if (PlayerStats.lvlMaxScore13 < scoreAmount)
                    PlayerStats.lvlMaxScore13 = scoreAmount;
                break;
            case 14:
                if (PlayerStats.lvlMaxScore14 < scoreAmount)
                    PlayerStats.lvlMaxScore14 = scoreAmount;
                break;
            case 15:
                if (PlayerStats.lvlMaxScore15 < scoreAmount)
                    PlayerStats.lvlMaxScore15 = scoreAmount;
                break;
            case 16:
                if (PlayerStats.lvlMaxScore16 < scoreAmount)
                    PlayerStats.lvlMaxScore16 = scoreAmount;
                break;
            case 17:
                if (PlayerStats.lvlMaxScore17 < scoreAmount)
                     PlayerStats.lvlMaxScore17 = scoreAmount;
                break;
            case 18:
                if (PlayerStats.lvlMaxScore18 < scoreAmount)
                    PlayerStats.lvlMaxScore18 = scoreAmount;
                break;
        }
        GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
    }

}
