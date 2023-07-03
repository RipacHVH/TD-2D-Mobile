using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBoosts : MonoBehaviour
{
    Button button;

    public bool HTKill = false;
    public bool Lightning = false;
    public bool Toxicity = false;
    public bool Fast = false;
    public bool SplashSlow = false;
    public bool NTSpecialT = false;

    public float boostCooldown = 0f;
    public float MaxCooldown;
    public float boostDuration = 0f;

    GameObject[] Enemies;
    GameObject[] Turrets;
    GameObject[] TurretsToDelete;
    Turret turretS;

    Image image;
    //Boosts MTboostsScript;
    private void Start()
    {
        //MTboostsScript = GameObject.Find("MaxTurrets Boost").GetComponent<Boosts>();
        image = gameObject.GetComponent<Image>();
        button = gameObject.GetComponent<Button>();
        gameObject.GetComponent<Image>().enabled = false;
        button.enabled = false;
        button.interactable = false;
    }
    private void Update()
    {
        
        if (boostCooldown >= 0)
        {
            
            boostCooldown -= Time.deltaTime;
        }
        image.fillAmount = (MaxCooldown - boostCooldown) / MaxCooldown;
        if (boostCooldown < 0)
        {
            image.fillAmount = 1f;
            button.interactable = true;
        }


        if(boostDuration >= 0)
        {
            boostDuration -= Time.deltaTime;
        }
        if(boostDuration < 0)
        {
            /*if(MTboostsScript.UsedBoostMax)
            {
                Fast = false;
                SplashSlow = false;
                NTSpecialT = false;
            }*/
            if (Fast)
            {
                foreach (GameObject turret in Turrets)
                {
                    if (turret != null)
                    {
                        
                        turretS = turret.GetComponentInChildren<Turret>();
                        TurretUpgradeMenu TurretUpgradeM = turret.GetComponent<TurretUpgradeMenu>();
                        if (turretS.FastTurret && TurretUpgradeM.lvlFour)
                        {
                            turretS.fireRate -= 1f;
                        }
                    }
                }
                Fast = false;
                Turrets = null;
            }
            if (SplashSlow)
            {
                SplashSlow = false;
            }
            if(NTSpecialT)
            {
                if (TurretsToDelete == null)
                {
                    TurretsToDelete = GameObject.FindGameObjectsWithTag("SpecialTurret");

                }
                foreach (GameObject turret in Turrets)
                {
                    turret.SetActive(true);

                }
                foreach (GameObject t in TurretsToDelete)
                {
                    Destroy(t);
                }
                TurretsToDelete = null;
                NTSpecialT = false;
            }
        }
    }
    public int instaKill=0;
    public void HTInstaKill()
    {
        HTKill = true;
        if(HTKill)
        {
            if (Turrets == null)
            {
                Turrets = GameObject.FindGameObjectsWithTag("Turret");
            }
            foreach (GameObject turret in Turrets)
            {
                if (turret != null)
                {
                    turretS = turret.GetComponentInChildren<Turret>();
                    TurretUpgradeMenu TurretUpgradeM = turret.GetComponent<TurretUpgradeMenu>();
                    if (turretS.HeavyTurret && TurretUpgradeM.lvlFour)
                    {
                        DamagePopup.Create(turret.transform.position, "+1 InstaKill Shot");
                        turretS.IKAShot = false;
                    }
                }
            }
        }
        instaKill = Turrets.Length;
        //Debug.Log(instaKill);
        HTKill = false;
        button.interactable = false;
        boostCooldown = 60f;
        MaxCooldown = boostCooldown;
    }
    public void ToxicInfection()
    {
        Toxicity = true;
        if (Toxicity)
        {
            if (Enemies == null)
            {
                Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            }

            var poisonAnim = Instantiate(GameAssets.i.Poison, transform.position, Quaternion.identity);
            Destroy(poisonAnim, 2.2f);
            //Poison falling Animation HERE

            foreach (GameObject enemy in Enemies)
            {
                if (enemy != null)
                {
                    Health enemieS = enemy.GetComponent<Health>();
                    enemieS.ToxicCooldown = 10f;
                    enemieS.ToxicDamage = 10f;
                }

            }
            Enemies = null;
            Toxicity = false;
            button.interactable = false;
            boostCooldown = 60f;
            MaxCooldown = boostCooldown;
        }
    }
    public void SlowSplash()
    {
        if (Turrets == null)
        {
            Turrets = GameObject.FindGameObjectsWithTag("Turret");
        }
        foreach (GameObject turret in Turrets)
        {
            if (turret != null)
            {
                turretS = turret.GetComponentInChildren<Turret>();
                TurretUpgradeMenu TurretUpgradeM = turret.GetComponent<TurretUpgradeMenu>();
                if (turretS.SlowerTurret && TurretUpgradeM.lvlFour)
                {
                    DamagePopup.Create(turret.transform.position, "Splash Damage ON");
                }
            }
        }
        boostDuration = 10f;
        SplashSlow = true;
        button.interactable = false;
        boostCooldown = 40f;
        MaxCooldown = boostCooldown;
    }
    public void LaserLightning()
    {
        Lightning = true;
        if (Lightning)
        {
            if (Enemies == null)
            {
                Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            }
            //Lightning animation HERE
            var lighteningAnim = Instantiate(GameAssets.i.Lightening, transform.position, Quaternion.identity);
            Destroy(lighteningAnim, 2.2f);
            foreach (GameObject enemy in Enemies)
            {
                if (enemy != null)
                {
                    Health enemieS = enemy.GetComponent<Health>();
                    enemieS.EnemyHealth -= 50f;
                }

            }
            Enemies = null;
            Lightning = false;
            button.interactable = false;
            boostCooldown = 60f;
            MaxCooldown = boostCooldown;
        }
    }


    GameObject NewTurret;
    public GameObject NTPrefab;
    public void NTSpecialTurret()
    {
        Turrets = null;
        NTSpecialT = true;
        if(NTSpecialT)
        {
            if (Turrets == null)
            {
                Turrets = GameObject.FindGameObjectsWithTag("Turret");
            }
            foreach (GameObject turret in Turrets)
            {
                if (turret != null)
                {
                    Turret turretS = turret.GetComponentInChildren<Turret>();
                    TurretUpgradeMenu TurretUpgradeM = turret.GetComponent<TurretUpgradeMenu>();
                    if (turretS.NormalTurret  && TurretUpgradeM.lvlFour)
                    {
                        DamagePopup.Create(turret.transform.position, "Special Turret");
                        turret.SetActive(false);
                        NewTurret = Instantiate(NTPrefab, turret.transform.position, turret.transform.rotation);
                    }

                }
            }
            button.interactable = false;
            boostDuration = 10f;
            boostCooldown = 60f;
            MaxCooldown = boostCooldown;
        }

    }
    public void FTShootFaster()
    {
        image.fillAmount = 0f;
        Fast = true;
        if (Fast)
        {
            if (Turrets == null)
            {
                Turrets = GameObject.FindGameObjectsWithTag("Turret");
            }
            foreach (GameObject turret in Turrets)
            {
                if (turret != null)
                {
                    turretS = turret.GetComponentInChildren<Turret>();
                    TurretUpgradeMenu TurretUpgradeM = turret.GetComponent<TurretUpgradeMenu>();
                    if (turretS.FastTurret && TurretUpgradeM.lvlFour)
                    {
                        DamagePopup.Create(turret.transform.position, "Fire Rate UP");
                        boostDuration = 5f;
                        turretS.fireRate += 1f;
                    }
                }
            }
            button.interactable = false;
            boostCooldown = 40f;
            MaxCooldown = boostCooldown;
        }
    }
}
