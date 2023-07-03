using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public GameObject warning;
    public TextMeshProUGUI countdown;
    public GameObject DeathScreen;
    public GameObject Revive;
    //public int ScoreToComplete;
    public GameObject[] EnemyTypes;
    //1-robot
    //2-sth else
    public Lives livesScript;
    public Enemy enemyScript;
    public Score scoreScript;
    public GameObject impactEffect;
    bool heartAnim = false;
    public bool enemySucceed = false;
    public int TurretNumb;
    public float DestroyCooldown = 10f;
    GameObject Rev;
    Revive RevScript;
    public bool expRev;
    private void Start()
    {

        DestroyCooldown = 10f;
        livesScript = GameObject.Find("LivesAmount").GetComponent<Lives>();
    }
    private void Update()
    {
        if (enemySucceed)
        {
            StartCoroutine(LivesAnim());
        }
        if (enemyScript.YouWon)
        {
            GameObject[] turetsD = GameObject.FindGameObjectsWithTag("Turret");
            warning.SetActive(true);

            if(countdown!=null)
            countdown.enabled = true;

            if (turetsD.Length <= 0)
            {
                Destroy(countdown);
                enemyScript.YouWon = false;
            }
            else
            {
                countdown.text = DestroyCooldown.ToString("0");
                DestroyCooldown -= Time.deltaTime;
            }
            if (DestroyCooldown < 0f)
            {
                TurretNumb = Random.Range(0, turetsD.Length);
                Destroy(turetsD[TurretNumb]);
                DestroyCooldown = 10f;
                /*foreach (GameObject turett in turetsD)
                {
                    Destroy(turett);
                }*/
            }
        }
        /*if (livesScript.lives <= 0)
        {
            //destroy all turrets and enemies
            GameObject[] enemiesD = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] turetsD = GameObject.FindGameObjectsWithTag("Turret");
            foreach (GameObject enemiee in enemiesD)
            {
                Destroy(enemiee);
                if (enemiesD.Length < 20)
                {
                    GameObject effectIns = Instantiate(impactEffect, enemiee.transform.position, enemiee.transform.rotation);
                    Destroy(effectIns, 2f);
                }
            }
            foreach (GameObject turett in turetsD)
            {
                Destroy(turett);
            }
        }*/
        
    }
    IEnumerator LivesAnim()
    {
        heartAnim = false;
        Image BHeart = livesScript.BrokenHeart;
        Image Heart = livesScript.Heart;
        if (!heartAnim)
        {
            SpriteRenderer goSprite = gameObject.GetComponent<SpriteRenderer>();
            BHeart.enabled = true;
            Heart.enabled = false;
            heartAnim = true;
            yield return new WaitForSeconds(0.2f);
        }
        if (heartAnim)
        {
            heartAnim = false;
            livesScript.lives -= 1;
            BHeart.enabled = false;
            Heart.enabled = true;
            enemySucceed = false;
            if (livesScript.lives <= 0 && !expRev)
                {
                Instantiate(Revive, Revive.transform.position, Quaternion.identity);
            }
            if (livesScript.lives <= 0 && scoreScript.scoreAmount < enemyScript.minScore && expRev)
            {
                //Instantiate(Revive, Revive.transform.position, Quaternion.identity);
                Time.timeScale = 1f;
                Destroy(enemyScript);
                scoreScript.ended = true;
                Instantiate(DeathScreen, DeathScreen.transform.position, Quaternion.identity);
                

            }
        }

    }


}
