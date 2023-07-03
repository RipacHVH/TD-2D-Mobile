using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float HPmultiplier;
    public Currency currencyScript;
    public Lives livesScript;
    public LevelManager lvlManager;
    public Enemy HPMScript;
    public float EnemyHealth;
    public float MaxHealth;
    public float EnemyShield;
    public float ToxicCooldown = 0f;
    public HealthBar HealthBar;
    public AlienScript alienScript;
    public ShieldScript ShieldScript;
    public GameObject HTGameObject;
    public GameObject impactEffect;
    public SpriteRenderer targetSprite;
    public SpriteRenderer poisonSprite;
    bool DoIt;
    public float Dublicate = 0f;
    public float ToxicDamage;

    [Header("Enemies")]

    public bool FatEnemyForPopup;


    public bool FatEnemy;
    public bool FatEnemy21;
    public bool FatEnemy22;
    public bool FatEnemy3;
    public bool NormalEnemy;
    public bool BirdEnemy;
    public bool AlienEnemy;
    public bool ShieldEnemy;



    private void Start()
    {
        HPMScript = GameObject.Find("Enemy Spawner").GetComponent<Enemy>();
        Dublicate = 0f;
        currencyScript = GameObject.Find("Currency").GetComponent<Currency>();
        lvlManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        targetSprite = gameObject.GetComponent<SpriteRenderer>();
        alienScript = gameObject.GetComponent<AlienScript>();
        ShieldScript = gameObject.GetComponent<ShieldScript>();
        MaxHealth = MaxHealth * HPMScript.HPmultiplier;
        EnemyHealth = MaxHealth;
    }

    private void Update()
    {
        HealthBar.SetHealth(EnemyHealth, MaxHealth);
        //Create Health UI
        ToxicCooldown -= Time.deltaTime;
        if (ToxicCooldown > 0f)
        {
            if (AlienEnemy && alienScript.InvinclibleEnabled)
            {
                //Debug.Log("Nema");
            }
            else
            {
                if (ShieldEnemy && !ShieldScript.NoShield)
                {
                    ShieldScript.ShieldAmount -= ToxicDamage * Time.deltaTime;
                    poisonSprite.enabled = true;
                }
                else
                {
                    
                    EnemyHealth -= ToxicDamage * Time.deltaTime;
                    poisonSprite.enabled = true;
                }
            }
        }
        if (ToxicCooldown <= 0)
        {
            if (poisonSprite != null)
            {
                poisonSprite.enabled = false;
            }
        }
        if (EnemyHealth <= 0)
        {
            if (!FatEnemy && !FatEnemy21 && !FatEnemy22)
            {
                GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effectIns, 2f);
                //Turret turret = HTGameObject.GetComponent<Turret>();
                //turret.list.Remove(gameObject);
                if(NormalEnemy)
                {
                currencyScript.money += currencyScript.minKillMoney * 10;
                }
                if(BirdEnemy)
                {
                currencyScript.money += currencyScript.minKillMoney * 5;
                }
                if(FatEnemy3)
                {
                currencyScript.money += currencyScript.minKillMoney * 100;
                }
                if(AlienEnemy)
                {
                    currencyScript.money += currencyScript.minKillMoney * 80;
                }
                if(ShieldEnemy)
                {
                    currencyScript.money += currencyScript.minKillMoney * 40;
                }
                Destroy(gameObject);
            }
            if (FatEnemy)
            {
                Dublicate = 1f;
            }
            if(FatEnemy21)
            {
                Dublicate = 2.1f;
            }
            if (FatEnemy22)
            {
                Dublicate = 2.2f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            lvlManager.enemySucceed = true;
            if (BirdEnemy)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
    //bool heartAnim = false;
    /*IEnumerator LivesAnim()
    {
        
    }*/

    public void Continue()
    {
        
    }
    
}
