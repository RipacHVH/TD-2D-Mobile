using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Revive : MonoBehaviour
{
    public bool ExpiredRevive;
    public LevelManager levelManagerScript;
    public Lives livesScript;
    public Enemy enemyScript;
    // Set the duration of the timer in seconds
    //public float timerDuration = 6f;
    public Image image;
    public TextMeshProUGUI ConnectionError;
    public float startTime = 5f; // The initial time of the timer
    float fillAmount;
    public AdsInitializer revAD;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        fillAmount = 1f;
        image.fillAmount = fillAmount;
        StartCoroutine(CountdownCoroutine());
        enemyScript = GameObject.Find("Enemy Spawner").GetComponent<Enemy>();
        livesScript = GameObject.Find("LivesAmount").GetComponent<Lives>();
        levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        GameObject[] enemiesD = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject[] turetsD = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject enemiee in enemiesD)
        {
            Destroy(enemiee);
            if (enemiesD.Length < 20)
            {
                GameObject effectIns = Instantiate(GameAssets.i.impactEffect, enemiee.transform.position, enemiee.transform.rotation);
                Destroy(effectIns, 2f);
            }
        }
        /*foreach (GameObject turett in turetsD)
        {
            Destroy(turett);
        }*/
        
    }

    void Update()
    {
        // Pause the game
        //Time.timeScale = 0f;

        // Show the revive button

        // Start a coroutine to wait for 3 seconds before hiding the button and resuming the game
        StartCoroutine(ReviveButtonCoroutine());
        
    }
    private IEnumerator CountdownCoroutine()
    {
        float timeLeft = startTime;

        while (fillAmount > 0f)
        {
            fillAmount = timeLeft - (startTime-1f);
            image.fillAmount = fillAmount;
            yield return new WaitForSecondsRealtime(0.01f);
            //по-голямо число = по-бързо въртене
            startTime += 0.3f * Time.unscaledDeltaTime;
        }

        image.fillAmount = 0f;
    }
    IEnumerator ReviveButtonCoroutine()
    {
        // Wait for 3 seconds
        yield return new WaitForSecondsRealtime(4f);
        levelManagerScript.expRev = true;
        enemyScript.expiRevive = true;
        levelManagerScript.enemySucceed = true;
        // Resume the game
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void ReviveB()
    {
        StartCoroutine(CheckInternetConnection());
        /*levelManagerScript.expRev = true;
        enemyScript.expiRevive = true;
        livesScript.lives = 3f;
        gameObject.SetActive(false);
        PlayerStats.Revives++;
        FindObjectOfType<PlayerStats>().SavePlayer();
        //RUN AD
        revAD.RunRewardedAD();*/
    }
    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            ConnectionError.enabled = true;
        }
        else
        {
            ConnectionError.enabled = false;
            levelManagerScript.expRev = true;
            enemyScript.expiRevive = true;
            livesScript.lives = 3f;
            gameObject.SetActive(false);
            PlayerStats.Revives++;
            FindObjectOfType<PlayerStats>().SavePlayer();
            //RUN AD
            revAD.RunRewardedAD();
        }
    }
}
