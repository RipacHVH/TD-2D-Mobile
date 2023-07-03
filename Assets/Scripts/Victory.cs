using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Score scoreScript;
    public Image[] Stars;
    [SerializeField]
    GameObject VText, VMenu, MMButton, RButton, Score, Star1, Star2, Star3;
    void Start()
    {
        //destroy all turrets and enemies
        GameObject[] enemiesD = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] turetsD = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject enemiee in enemiesD)
        {
            Destroy(enemiee);
            if (enemiesD.Length < 20)
            {
                GameObject effectIns = Instantiate(GameAssets.i.impactEffect, enemiee.transform.position, enemiee.transform.rotation);
                Destroy(effectIns, 2f);
            }
        }
        foreach (GameObject turett in turetsD)
        {
            Destroy(turett);
        }
        Enemy Spawner = GameObject.Find("Enemy Spawner").GetComponent<Enemy>();
        scoreScript = GameObject.Find("Score").GetComponent<Score>();

        if (scoreScript.scoreAmount >= Spawner.minScore)
        {
            Stars[0].enabled = true;
        }
        if (scoreScript.scoreAmount >= Spawner.minScore * 2)
        {
            Stars[1].enabled = true;
        }
        if (scoreScript.scoreAmount >= Spawner.minScore * 3)
        {
            Stars[2].enabled = true;
        }
        LeanTween.scale(VText, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeInOutBack).setOnComplete(LevelComplete);
        LeanTween.moveLocal(VText, new Vector3(0f, 190f, 0f), 1f).setDelay(1f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(VText, new Vector3(0.252f, 0.252f, 0.252f), 1f).setDelay(1f).setEase(LeanTweenType.easeInOutCubic);
    }
    void LevelComplete() 
    {
        LeanTween.moveLocal(VMenu, new Vector3(0f, 0f, 0f), 0.7f).setDelay(0.2f).setEase(LeanTweenType.easeOutCirc).setOnComplete(StarAnim);
        LeanTween.scale(MMButton, new Vector3(0.15f, 0.15f, 0.15f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(RButton, new Vector3(0.15f, 0.15f, 0.15f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Score, new Vector3(1f, 1f, 1f), 2f).setDelay(0.6f).setEase(LeanTweenType.easeOutQuart);
        /*LeanTween.alpha(coins.GetComponent<RectTransform>(), 1f, .5f).setDelay(1.1f);
        LeanTween.alpha(gems.GetComponent<RectTransform>(), 1f, .5f).setDelay(1.2f);*/
    }
    void StarAnim()
    {
        if (Star1 != null)
        {
            LeanTween.scale(Star1, new Vector3(0.7f, 0.7f, 0.7f), 2f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Star2, new Vector3(0.7f, 0.7f, 0.7f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Star3, new Vector3(0.7f, 0.7f, 0.7f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
        }
    }
}
