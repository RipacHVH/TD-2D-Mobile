using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DWScore : MonoBehaviour
{
    public TextMeshProUGUI DWscoreText;
    public float score;
    public TextMeshProUGUI minScore;
    private float TotalScore;
    private float startTime;
    public bool minScoreB;
    Enemy enemyScript;
    void Start()
    {
        
        startTime = Time.time;
        //DWscoreText = gameObject.GetComponent<TextMeshProUGUI>();
        if (minScoreB)
        {
            enemyScript = GameObject.Find("Enemy Spawner").GetComponent<Enemy>();
            minScore.text = enemyScript.minScore.ToString();
        }
        else
        {
            score = 0f;
            TotalScore = 0f;
            StartCoroutine(IncreaseNumber());
        }
    }
    float t;
    private void Update()
    {
        t = (Time.time - startTime) / TotalScore;
    }
    private IEnumerator IncreaseNumber()
    {
        
        TotalScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().scoreAmount;

        while (score < TotalScore)
        {
            score = Mathf.Lerp(score, TotalScore, t);
            DWscoreText.text = Mathf.RoundToInt(score).ToString();
            yield return null;
        }
    }
    public void SkipAnim()
    {
        score = TotalScore;
        DWscoreText.text = Mathf.RoundToInt(score).ToString();
    }    
}
