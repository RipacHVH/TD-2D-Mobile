using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Boosts : MonoBehaviour
{
    [Header("Main")]
    public float Charges = 1f;
    public TextMeshProUGUI ChargesCountText;
    Button button;
    public float BoostCooldown = 0f;
    public float MaxCooldown;

    Image image;

    Currency currencyScript;
    [Header("Max Turrets")]
    
    GameObject[] Turrets;
    public GameObject NTPrefab;
    public GameObject FTPrefab;
    public GameObject HTPrefab;
    public GameObject STPrefab;
    public GameObject TTPrefab;
    public GameObject LTPrefab;
    public GameObject NewTurret;
    public bool UsedBoostMax = false;
    GameObject[] TurretsToDelete;

    [Header("Slow")]

    GameObject[] Enemies;
    public bool UsedBoostSlow = false;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        button = gameObject.GetComponent<Button>();
        button.interactable = true;
    }
    void Update()
    {
        if (Charges <= 0f)
        {
            BoostCooldown -= Time.deltaTime;
            button.interactable = false;
        }
        else
        {
            image.fillAmount = (MaxCooldown - BoostCooldown) / MaxCooldown;

            BoostCooldown -= Time.deltaTime;
        }
        if (BoostCooldown < 0f && UsedBoostSlow)
        {
            
            foreach (GameObject enemy in Enemies)
            {
                if (enemy != null)
                {
                    Waypoints enemieS = enemy.GetComponent<Waypoints>();
                    enemieS.slowBoost = false;
                }

            }
            UsedBoostSlow = false;
            Enemies = null;
        }

        if (BoostCooldown < 0f && Charges >0f)
        {
            image.fillAmount = 1f;
            button.interactable = true;
        }

        //Maxed turrets
        if(BoostCooldown < 0f && UsedBoostMax)
        {
            image.fillAmount = 1f;
            if (TurretsToDelete == null)
            {
            TurretsToDelete = GameObject.FindGameObjectsWithTag("Clone");

            }
        foreach (GameObject turret in Turrets)
            {
                if(turret!=null)
                turret.SetActive(true);
            
            }
               foreach (GameObject t in TurretsToDelete)
            {
                Destroy(t);
            }
            UsedBoostMax = false;
            Turrets = null;
            TurretsToDelete = null;
        }
    }
    public void SlowEnemies()
    {
        //button.interactable = false;
        if (BoostCooldown < 0f)
        {
            Charges--;
            ChargesCountText.text = Charges.ToString();
            if (Enemies == null)
            {
                Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            }
            BoostCooldown = 7f;
            MaxCooldown = BoostCooldown;
            foreach (GameObject enemy in Enemies)
            {
                if (enemy != null)
                {
                    Waypoints enemieS = enemy.GetComponent<Waypoints>();
                    enemieS.slowBoost = true;
                }
                button.interactable = false;
                UsedBoostSlow = true;
            }
        }
    }

    public void MaxedTurrets()
    {
        //button.interactable = false;
        if (BoostCooldown < 0f)
        {

            Charges--;
            ChargesCountText.text = Charges.ToString();
            if (Turrets == null)
            {
            Turrets = GameObject.FindGameObjectsWithTag("Turret");
            }
            BoostCooldown = 5f;
            MaxCooldown = BoostCooldown;
            foreach (GameObject turret in Turrets)
            {
                if (turret != null)
                {
                    Turret turretS = turret.GetComponentInChildren<Turret>();
                    TurretUpgradeMenu turretUP = turret.GetComponent<TurretUpgradeMenu>();
                    if (!turretUP.lvlFour)
                    {
                        turret.SetActive(false);
                    }
                    if (turretS.FastTurret && !turretUP.lvlFour)
                    {
                        NewTurret = Instantiate(FTPrefab, turret.transform.position, turret.transform.rotation);
                    }
                    if (turretS.NormalTurret && !turretUP.lvlFour)
                    {
                        NewTurret = Instantiate(NTPrefab, turret.transform.position, turret.transform.rotation);
                    }
                    if (turretS.HeavyTurret && !turretUP.lvlFour)
                    {
                        Vector2 direction2 = turretS.direction;
                        NewTurret = Instantiate(HTPrefab, turret.transform.position, turret.transform.rotation);
                        NewTurret.GetComponentInChildren<Turret>().direction = direction2;
                        NewTurret.GetComponentInChildren<Turret>().MaxBoostedHT = true;
                    }
                    if (turretS.SlowerTurret && !turretUP.lvlFour)
                    {
                        NewTurret = Instantiate(STPrefab, turret.transform.position, turret.transform.rotation);
                    }
                    if (turretS.ToxicTurret && !turretUP.lvlFour)
                    {
                        NewTurret = Instantiate(TTPrefab, turret.transform.position, turret.transform.rotation);
                    }
                    if (turretS.LaserTurret && !turretUP.lvlFour)
                    {
                        NewTurret = Instantiate(LTPrefab, turret.transform.position, turret.transform.rotation);
                    }
                    if (!turretUP.lvlFour)
                    {
                        NewTurret.tag = "Clone";
                        NewTurret.GetComponentInChildren<TurretUpgradeMenu>().Boosted = true;
                    }
                    UsedBoostMax = true;
                }
            }
            button.interactable = false;
            UsedBoostMax = true;
        }
    }
    public void GetMoney()
    {
        StartCoroutine(CheckInternetConnection());
        /*AdsInitializer Ad = GameObject.Find("Main Camera").GetComponent<AdsInitializer>();
        currencyScript = GameObject.Find("Currency").GetComponent<Currency>();
        Ad.GetMoney = true;
        Ad.RunRewardedAD();
        //currencyScript.money += 1000f;*/
    }
    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            DamagePopup.Create(transform.position, "Connection Error");
        }
        else
        {
            AdsInitializer Ad = GameObject.Find("Main Camera").GetComponent<AdsInitializer>();
            currencyScript = GameObject.Find("Currency").GetComponent<Currency>();
            Ad.GetMoney = true;
            Ad.RunRewardedAD();
            //currencyScript.money += 1000f;
        }
    }
}
