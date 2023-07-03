using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class TurretUpgradeMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Canvas TurretUI;
    public bool Boosted = false;
    private GameObject cancButton;

    public SpriteRenderer RangeSprite;
    private bool MouseOnObject = false;
    public Turret TurretScript;
    [Header("UI")]
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI fireRateText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI slowText;
    public TextMeshProUGUI SellPriceText;
    public TextMeshProUGUI UpgradePriceText;

    [Header("UPGRADE")]
    Currency currencyS;
    public int TurretPrice;
    float UpgradePrice = 0f;
    float LastUpgradeCost = 0f;
    private int UpgradeLevel;
    public SpriteRenderer GetTower;
    public SpriteRenderer GetTurret;

    public float StarsRequired;

    public GameObject BulletBLUE;
    public GameObject BulletGREEN;
    public GameObject BulletORANGE;
    public GameObject BulletRED;

    [Header("Turret/Tower")]
    public Sprite OrangeTower;
    public Sprite OrangeTurret;
    public Sprite RedTower;
    public Sprite RedTurret;
    public Sprite GreenTower;
    public Sprite GreenTurret;

    [Header("Boosts")]
    public GameObject TBoost;

    public GameObject CanvasToDelete;

    public Image UButton;
    private Color UBcolor;

    public bool lvlFour = false;
    
    private void OnMenu()
    {
        if (Input.GetMouseButtonDown(0) && MouseOnObject && gameObject.tag == "Turret")
        {
            TurretUI.enabled = true;
            RangeSprite.enabled = true;
            cancButton = GameObject.Find("Cancel");
            if (cancButton != null)
                cancButton.SetActive(false);
        }
    }
    private void OffMenu()
    {
        if (Input.GetMouseButtonDown(0) && !MouseOnObject)
        {
            TurretUI.enabled = false;
            RangeSprite.enabled = false;
            //cancButton.SetActive(true);
        }
    }
    private void Start()
    {
        //cancButton = GameObject.Find("Cancel");
        UpgradePrice = TurretPrice * 1.6f;
        currencyS = GameObject.Find("Currency").GetComponent<Currency>();
        UpgradePriceText.text = (TurretPrice * 1.6f).ToString();
        SellPriceText.text = Mathf.Round((LastUpgradeCost + TurretPrice) / 1.6f).ToString();
        /* if (gameObject.tag == "Clone")
         {
             Destroy(CanvasToDelete);
         }*/
        UpgradeLevel = 1;
        AddPhysics2DRaycaster();
    }
    public void SellTurret()
    {
        if (TurretScript.LaserTurret && TurretScript.targetSprite != null)
        {
            TurretScript.targetSprite.color = Color.white;
        }
        Destroy(gameObject);
        currencyS.money += (LastUpgradeCost + TurretPrice) / 1.6f;
        //Debug.Log(LastUpgradeCost);
        currencyS.money = Mathf.Round(currencyS.money);
        //give money back
    }
    void Update()
    {
        if (StarsRequired > PlayerStats.Stars || UpgradePrice > currencyS.money)
        {
            UButton.color = new Color(100f, 100f, 100f, 0.5f);
        }
        else
        {
            UButton.color = new Color(255, 255, 255, 1);
        }
        if (UpgradeLevel == 1)
        {
            UpgradePrice = TurretPrice * 1.6f;
        }
        if (UpgradeLevel == 2)
        {
            UpgradePrice = (TurretPrice * 1.6f) * 5;
        }
        if (UpgradeLevel == 3)
        {
            UpgradePrice = (TurretPrice * 1.6f) * 25;
        }
        

        OnMenu();
        OffMenu();
        if(Boosted)
        {
            UpgradeLevel = 3;
            UpgradeLevels();
            Boosted = false;
        }

    }
  
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOnObject = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOnObject = false;

    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
    public void UpgradeTurret()
    {
        UpgradeLevels();
    }

    void UpgradeLevels()
    {
        if (UpgradeLevel <= 3 && PlayerStats.Stars < StarsRequired && !Boosted)
        {
            DamagePopup.Create(transform.position, "Not Enough Stars(" + PlayerStats.Stars + "/" + StarsRequired + ")");
        }
        if (UpgradeLevel <= 3 && UpgradePrice > currencyS.money && PlayerStats.Stars >= StarsRequired && !Boosted)
        {
            DamagePopup.Create(transform.position, "Not Enough Money(" + currencyS.money + "/" + UpgradePrice + ")");
        }

        if (Boosted)
        {
            GetTower.sprite = RedTower;
            GetTurret.sprite = RedTurret;
            TurretScript.bulletPrefab = BulletRED;
            UpgradeCode();
        }

        if (PlayerStats.Stars >= StarsRequired || Boosted){
            if (UpgradeLevel == 3 && PlayerStats.Stars >= StarsRequired || Boosted)
            {
                    UpgradePrice = (TurretPrice * 1.6f) * 25;
                    if (UpgradePrice <= currencyS.money)
                    {
                        GetTower.sprite = RedTower;
                        GetTurret.sprite = RedTurret;
                        TurretScript.bulletPrefab = BulletRED;

                        currencyS.money -= UpgradePrice;
                        UpgradePriceText.text = "Maxed";
                        LastUpgradeCost = (TurretPrice * 1.6f) * 25;
                        SellPriceText.text = Mathf.Round((LastUpgradeCost + TurretPrice) / 1.6f).ToString();
                        UpgradeCode();
                    //Special boosts
                    if (!Boosted)
                    {
                        if (TurretScript.ToxicTurret && gameObject.tag != "Clone")
                        {
                            lvlFour = true;
                            TBoost = GameObject.Find("Toxic Boost");
                            TBoost.GetComponent<Button>().enabled = true;
                            TBoost.GetComponent<Image>().enabled = true;
                            TBoost = null;
                        }
                        if (TurretScript.NormalTurret && gameObject.tag != "Clone")
                        {
                            lvlFour = true;
                            TBoost = GameObject.Find("Special Turret");
                            TBoost.GetComponent<Button>().enabled = true;
                            TBoost.GetComponent<Image>().enabled = true;
                            TBoost = null;
                        }
                        if (TurretScript.FastTurret && gameObject.tag != "Clone")
                        {
                            lvlFour = true;
                            TBoost = GameObject.Find("Fast Boost");
                            TBoost.GetComponent<Button>().enabled = true;
                            TBoost.GetComponent<Image>().enabled = true;
                            TBoost = null;
                        }
                        if (TurretScript.HeavyTurret && gameObject.tag != "Clone")
                        {
                            lvlFour = true;
                            TBoost = GameObject.Find("HT Boost");
                            TBoost.GetComponent<Button>().enabled = true;
                            TBoost.GetComponent<Image>().enabled = true;
                            TBoost = null;
                        }
                        if (TurretScript.SlowerTurret && gameObject.tag != "Clone")
                        {
                            lvlFour = true;
                            TBoost = GameObject.Find("Slow Splash");
                            TBoost.GetComponent<Button>().enabled = true;
                            TBoost.GetComponent<Image>().enabled = true;
                            TBoost = null;
                        }
                        if (TurretScript.LaserTurret && gameObject.tag != "Clone")
                        {
                            lvlFour = true;
                            TBoost = GameObject.Find("Laser Boost");
                            TBoost.GetComponent<Button>().enabled = true;
                            TBoost.GetComponent<Image>().enabled = true;
                            TBoost = null;
                        }
                    }
                        UpgradeLevel++;
                    }
                    
                }
            }
            if (UpgradeLevel == 2 && PlayerStats.Stars >= StarsRequired)
            {
                UpgradePrice = (TurretPrice * 1.6f) * 5;
                if (UpgradePrice <= currencyS.money)
                {
                    GetTower.sprite = OrangeTower;
                    GetTurret.sprite = OrangeTurret;
                    TurretScript.bulletPrefab = BulletORANGE;
                    StarsRequired = StarsRequired * 1.5f;
                    currencyS.money -= UpgradePrice;
                    UpgradePriceText.text = ((TurretPrice * 1.6f) * 25).ToString();
                    LastUpgradeCost = (TurretPrice * 1.6f) * 5;
                    SellPriceText.text = Mathf.Round((LastUpgradeCost + TurretPrice) / 1.6f).ToString();
                    UpgradeCode();
                    UpgradeLevel++;

                }

            }
            if (UpgradeLevel == 1 && PlayerStats.Stars >= StarsRequired)
            {
                UpgradePrice = TurretPrice * 1.6f;
                if (UpgradePrice <= currencyS.money)
                {
                    GetTower.sprite = GreenTower;
                    GetTurret.sprite = GreenTurret;
                    TurretScript.bulletPrefab = BulletGREEN;
                    StarsRequired = StarsRequired * 2;
                    currencyS.money -= UpgradePrice;
                    UpgradePriceText.text = ((TurretPrice * 1.6f) * 5).ToString();
                    LastUpgradeCost = TurretPrice * 1.6f;
                    SellPriceText.text = Mathf.Round((LastUpgradeCost + TurretPrice) / 1.6f).ToString();
                    UpgradeCode();
                    UpgradeLevel++;

                }
            }
           
            
            if (UpgradeLevel < 1)
            {
                DamagePopup.Create(transform.position, "Something's wrong");
            }
            if (UpgradeLevel > 3)
            {
                DamagePopup.Create(transform.position, "Max Level Reached");
            }
        }
        
    
    void UpgradeCode()
    {
        if (TurretScript.ToxicTurret)
        {
            //DAMAGE
            TurretScript.CurrentToxicDamage = TurretScript.CurrentToxicDamage * 2;
            damageText.text = TurretScript.CurrentToxicDamage.ToString() + "/s";

            //FireRate
            TurretScript.fireRate += 0.75f;
            fireRateText.text = TurretScript.fireRate.ToString();
            if(Boosted)
            {
                //DAMAGE
            TurretScript.CurrentToxicDamage = 40;
            damageText.text = TurretScript.CurrentToxicDamage.ToString() + "/s";

            //FireRate
            TurretScript.fireRate = 2.75f;
            fireRateText.text = TurretScript.fireRate.ToString();
            }
        }

        if (TurretScript.HeavyTurret)
        {
            //DAMAGE
            TurretScript.Damage += 30;
            //TurretScript.Damage += 15;
            damageText.text = TurretScript.Damage.ToString();

            //FireRate
            TurretScript.fireRate += 0.05f;
            fireRateText.text = TurretScript.fireRate.ToString();
            if(Boosted)
            {
                //DAMAGE
            TurretScript.Damage = 105;
            damageText.text = TurretScript.Damage.ToString();

            //FireRate
            TurretScript.fireRate = 0.28f;
            fireRateText.text = TurretScript.fireRate.ToString();
            }
        }

        if (TurretScript.LaserTurret)
        {
            //DAMAGE
            TurretScript.Damage += 0.5f;
            damageText.text = (TurretScript.Damage * 10f).ToString() + "/s";

            if(Boosted)
            {
                    //DAMAGE
                TurretScript.Damage = 1.84f;
                damageText.text = (TurretScript.Damage * 10f).ToString() + "/s";
                
            }
        }

        if(TurretScript.SlowerTurret)
        {
            //DAMAGE
            /*TurretScript.Damage = TurretScript.Damage * 2;
            damageText.text = TurretScript.Damage.ToString();*/

            //FireRate
            TurretScript.fireRate += 0.20f;
            fireRateText.text = TurretScript.fireRate.ToString();

            //Slowing
            TurretScript.CurrentSlowingCooldown += 3;
            slowText.text = TurretScript.CurrentSlowingCooldown.ToString() + " sec.";

            if(Boosted)
            {
                //DAMAGE
            /*TurretScript.Damage = 40f;
            damageText.text = TurretScript.Damage.ToString();*/

            //FireRate
            TurretScript.fireRate = 1.1f;
            fireRateText.text = TurretScript.fireRate.ToString();

            //Slowing
            TurretScript.CurrentSlowingCooldown = 14;
            slowText.text = TurretScript.CurrentSlowingCooldown.ToString() + " sec.";

            }
        }

        if (TurretScript.FastTurret)
        {
            //DAMAGE
            TurretScript.Damage = TurretScript.Damage + 5;
            damageText.text = TurretScript.Damage.ToString();

            //FireRate
            TurretScript.fireRate += 0.7f;
            fireRateText.text = TurretScript.fireRate.ToString();
            if(Boosted)
            {
                //DAMAGE
            TurretScript.Damage = 20;
            damageText.text = TurretScript.Damage.ToString();

            //FireRate
            TurretScript.fireRate = 4.1f;
            fireRateText.text = TurretScript.fireRate.ToString();
            }
        }

        if (TurretScript.NormalTurret)
        {
            //DAMAGE
            TurretScript.Damage = TurretScript.Damage * 2;
            damageText.text = TurretScript.Damage.ToString();

            //FireRate
            TurretScript.fireRate += 0.3f;
            fireRateText.text = TurretScript.fireRate.ToString();
            if(Boosted)
            {
                //DAMAGE
            TurretScript.Damage = 80f;
            damageText.text = TurretScript.Damage.ToString();

            //FireRate
            TurretScript.fireRate = 1.4f;
            fireRateText.text = TurretScript.fireRate.ToString();


            }
        }

        //RANGE
        if (!TurretScript.HeavyTurret)
        {
            TurretScript.Range += 0.2f;
            rangeText.text = TurretScript.Range.ToString(".0");
            TurretScript.gameObject.transform.localScale =
                new Vector2(TurretScript.Range, TurretScript.Range);
                if(Boosted)
                {
                    if (TurretScript.NormalTurret)
                    {
                        TurretScript.Range = 4.1f;
                        
                    }

                    if (TurretScript.FastTurret)
                    {
                        TurretScript.Range = 4.1f;
            
                    }
                    
                    if(TurretScript.SlowerTurret)
                    {
                        TurretScript.Range = 4.6f;
            
                    }
                    
                    if (TurretScript.ToxicTurret)
                    {
                        TurretScript.Range = 4.6f;
            
                    }
                    if (TurretScript.LaserTurret)
                    {
                        TurretScript.Range = 5.6f;

                    }
                rangeText.text = TurretScript.Range.ToString(".0");
            TurretScript.gameObject.transform.localScale =
                new Vector2(TurretScript.Range, TurretScript.Range);
                    
                }
        }
       
        
        
        
    }
    

    
    
}
