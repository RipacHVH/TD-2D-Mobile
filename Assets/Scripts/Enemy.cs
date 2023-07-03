using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public bool Harder;
    public float HPMM;
    public float HPmultiplier = 1f;
    public int minScore;

    public int Difficulty = 1;
    public int Level;
    //4
    public int currentWave;
    //1 (4)
    public int unclockedEnemies;
    //first wave enemies. 1/2 less each wave.
    public float enemiesPerWave;
    public float enemiesPerWaveToCut = 0.5f;
    float startEnemiesPerWave;
    public bool YouWon;
    int enemyIndex;
    bool stop = false;
    float StartSpawnRate;
    public float SpawnRate;

    public GameObject[] EnemyPrefab;
    public Transform EnemySpawner;
    bool ReadyToSpawn = false;
    LevelManager levelManagerScript;
    public Lives livesScript;
    public Score scoreScript;
    public GameObject Winscreen;
    public bool expiRevive;

    private void Start()
    {
        StartSpawnRate = SpawnRate;
        startEnemiesPerWave = enemiesPerWave;
        levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        StartCoroutine(SpawnTimer());
        currentWave = 1;

    }
    void LvlCompleted()
    {
        switch (Level)
        {
            case 1:
                if (PlayerStats.lvldifficultyCompleted1 < Difficulty)
                    PlayerStats.lvldifficultyCompleted1 = Difficulty;
                break;
            case 2:
                if (PlayerStats.lvldifficultyCompleted2 < Difficulty)
                    PlayerStats.lvldifficultyCompleted2 = Difficulty;
                break;
            case 3:
                if (PlayerStats.lvldifficultyCompleted3 < Difficulty)
                    PlayerStats.lvldifficultyCompleted3 = Difficulty;
                break;
            case 4:
                if (PlayerStats.lvldifficultyCompleted4 < Difficulty)
                    PlayerStats.lvldifficultyCompleted4 = Difficulty;
                break;
            case 5:
                if (PlayerStats.lvldifficultyCompleted5 < Difficulty)
                    PlayerStats.lvldifficultyCompleted5 = Difficulty;
                break;
            case 6:
                    if(PlayerStats.lvldifficultyCompleted6 < Difficulty)
                    PlayerStats.lvldifficultyCompleted6 = Difficulty;
                break;
            case 7:
                if (PlayerStats.lvldifficultyCompleted7 < Difficulty)
                    PlayerStats.lvldifficultyCompleted7 = Difficulty;
                break;
            case 8:
                if (PlayerStats.lvldifficultyCompleted8 < Difficulty)
                    PlayerStats.lvldifficultyCompleted8 = Difficulty;
                break;
            case 9:
                if (PlayerStats.lvldifficultyCompleted9 < Difficulty)
                    PlayerStats.lvldifficultyCompleted9 = Difficulty;
                break;
            case 10:
                if (PlayerStats.lvldifficultyCompleted10 < Difficulty)
                    PlayerStats.lvldifficultyCompleted10 = Difficulty;
                break;
            case 11:
                if (PlayerStats.lvldifficultyCompleted11 < Difficulty)
                    PlayerStats.lvldifficultyCompleted11 = Difficulty;
                break;
            case 12:
                if (PlayerStats.lvldifficultyCompleted12 < Difficulty)
                    PlayerStats.lvldifficultyCompleted12 = Difficulty;
                break;
            case 13:
                if (PlayerStats.lvldifficultyCompleted13 < Difficulty)
                    PlayerStats.lvldifficultyCompleted13 = Difficulty;
                break;
            case 14:
                if (PlayerStats.lvldifficultyCompleted14 < Difficulty)
                    PlayerStats.lvldifficultyCompleted14 = Difficulty;
                break;
            case 15:
                if (PlayerStats.lvldifficultyCompleted15 < Difficulty)
                    PlayerStats.lvldifficultyCompleted15 = Difficulty;
                break;
            case 16:
                if (PlayerStats.lvldifficultyCompleted16 < Difficulty)
                    PlayerStats.lvldifficultyCompleted16 = Difficulty;
                break;
            case 17:
                if (PlayerStats.lvldifficultyCompleted17 < Difficulty)
                    PlayerStats.lvldifficultyCompleted17 = Difficulty;
                break;
            case 18:
                if (PlayerStats.lvldifficultyCompleted18 < Difficulty)
                    PlayerStats.lvldifficultyCompleted18 = Difficulty;
                break;
        }
    }

    private void Update()
    {
        //Check If You Win
        if (livesScript.lives <= 0 && scoreScript.scoreAmount > minScore && expiRevive)
        {
            Time.timeScale = 1f;
            Difficulty = 1;
            if (scoreScript.scoreAmount > minScore * 2)
            {
                Difficulty = 2;
            }
            if (scoreScript.scoreAmount > minScore * 3)
            {
                Difficulty = 3;
            }

            LvlCompleted();

            if (!stop)
            {
                scoreScript.ended = true;
                Instantiate(Winscreen, Winscreen.transform.position, Quaternion.identity);
                enemiesPerWave -= 100;
                stop = true;
            }
            if (Level > PlayerStats.levelWon)
                PlayerStats.levelWon = Level;
            GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
        }

        Math.Ceiling(enemiesPerWave);
        //Spawning
        if (ReadyToSpawn && enemiesPerWave > 0)
        {
            enemyIndex = Random.Range(currentWave - 4, currentWave);
            if (enemyIndex < 0)
                enemyIndex = 0;
            if (currentWave >= unclockedEnemies * 4)
            {
                enemiesPerWave = 50;

                /*if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                    YouWon = true;*/
            }
            if (scoreScript.scoreAmount > minScore * 6)
            {
                enemyIndex = Random.Range(unclockedEnemies, currentWave);
            }
            if (scoreScript.scoreAmount > minScore * 7)
            {
                enemyIndex = Random.Range(unclockedEnemies*2, currentWave);
            }
            if (scoreScript.scoreAmount > minScore * 8)
            {
                enemyIndex = Random.Range(unclockedEnemies*3, currentWave);
            }

            GameObject SpawnEnemy = Instantiate(levelManagerScript.EnemyTypes[enemyIndex], transform.position, Quaternion.identity);
            enemiesPerWave--;
            if (enemiesPerWave <= 0)
            {
                currentWave++;
                enemiesPerWave = startEnemiesPerWave * enemiesPerWaveToCut;
                enemiesPerWave = Mathf.Round(enemiesPerWave);
                startEnemiesPerWave = enemiesPerWave;
            }
            if (scoreScript.scoreAmount > minScore)
            {
                SpawnRate = StartSpawnRate - 0.5f;
                if (Harder)
                {
                    HPmultiplier = HPMM;
                }
            }
            if (scoreScript.scoreAmount > minScore * 2)
            {
                SpawnRate = StartSpawnRate - 1f;
                if(Harder)
                {
                    HPmultiplier = HPMM + 0.2f;
                }
                //ÕPmultiplier = HPmultiplier + 0.1f;
            }
            if (scoreScript.scoreAmount > minScore * 3)
            {
                SpawnRate = StartSpawnRate - 1.5f;
                if (Harder)
                {
                    HPmultiplier = HPMM + 0.4f;
                }
                //HPmultiplier = HPmultiplier + 0.5f;
            }
            if (scoreScript.scoreAmount > minScore * 4)
            {
                SpawnRate = StartSpawnRate - 2f;
                HPmultiplier = HPMM + 0.8f;
            }
            if (scoreScript.scoreAmount > minScore * 5)
            {
                SpawnRate = StartSpawnRate - 2.5f;
                HPmultiplier = HPMM + 1.5f;
            }
            //Grand final
            if (scoreScript.scoreAmount > minScore * 9)
            {
                SpawnRate = StartSpawnRate - 2.75f;
                HPmultiplier = HPMM + 5f;
            }
            if (scoreScript.scoreAmount > minScore * 10)
            {
                YouWon = true;
            }
            StartCoroutine(SpawnTimer());
        }
    }

    IEnumerator SpawnTimer()
    {
        ReadyToSpawn = false;
        yield return new WaitForSeconds(SpawnRate);
        ReadyToSpawn = true;

    }
}
