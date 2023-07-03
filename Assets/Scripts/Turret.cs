using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Header("Shooting")]
    public float Range;
    public float Damage;
    public float fireRate;
    private float fireCountdown = 1f;
    public float CurrentToxicDamage = 3f;
    public float CurrentSlowingCooldown = 5f;
    [Header("Additional")]

    public bool ToxicTurret;
    public bool SlowerTurret;
    public bool LaserTurret;
    public bool SpecialTurret;
    public bool NormalTurret;
    public bool FastTurret;
    public bool Test;
    SpriteRenderer rangeSprite;
    public SpriteRenderer targetSprite;
    [Header("Following")]
    GameObject scndBullet;
    Bullet bullet2;
    public Transform firePoint2;

    private bool notLocked = true;
    //private bool targetChosen = false;
    public GameObject bulletPrefab;
    TurretBoosts instaKillScript;
    public Transform firePoint;
    public float rotationSpeed = 20f;
    public float rotationModifier = 90f;
    public Transform Cannon;
    Vector3 vectorToTarget;
    private Transform target;
    private Queue<Transform> targetQueue = new Queue<Transform>();
    public Health targetHealth;
    public AlienScript targetAlien;
    public ShieldScript ShieldScript;
    public Waypoints targetWaypoints;

    [Header("Heavy Turret")]

    private GameObject HeavyTurretTargetText;
    public List<GameObject> list = new List<GameObject>();
    Health HTEnemy;
    ShieldScript HTEnemyShield;
    AlienScript HTEnemyAlien;
    [SerializeField] public bool HeavyTurret;
    public Transform endPoint;
    TurretBoosts TBoostScript;
    Boosts boostsScript;
    public Vector2 direction;



    TurretUpgradeMenu TurretUMenuScript;
    private void Start()
    {
        if (instaKillScript == null)
            instaKillScript = GameObject.Find("HT Boost").GetComponent<TurretBoosts>();
        boostsScript = GameObject.Find("MaxTurrets Boost").GetComponent<Boosts>();
        rangeSprite = gameObject.GetComponent<SpriteRenderer>();
        rangeSprite.enabled = false;
        if (!HeavyTurret)
        {
            gameObject.transform.localScale = new Vector2(Range, Range);
        }
        if(HeavyTurret && notLocked)
        {
            HeavyTurretTargetText = GameObject.Find("Text");
            if (!MaxBoostedHT)
            {
                //[TEXT] Click on the screen to rotate the turret
                //[TEXT] YOU CAN ROTATE THE TURRET ONLY ONCE!
                HeavyTurretTargetText.SetActive(true);
                TBoostScript = GameObject.Find("HT Boost").GetComponent<TurretBoosts>();
            }
            else
            {
                HeavyTurretTargetText.SetActive(false);
                TBoostScript = GameObject.Find("HT Boost").GetComponent<TurretBoosts>();
            }
        }
    }
    public bool MaxBoostedHT = false;
    void Additional()
    {
        if (HeavyTurret && Input.GetMouseButtonDown(0) && notLocked)
        {
            
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Cannon.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Cannon.transform.rotation = Quaternion.Slerp(Cannon.transform.rotation, rotation, 500f);
            HeavyTurretTargetText.SetActive(false);
            notLocked = false;
        }
        if(HeavyTurret && MaxBoostedHT && notLocked)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Cannon.transform.rotation = Quaternion.Slerp(Cannon.transform.rotation, rotation, 500f);
            HeavyTurretTargetText.SetActive(false);
            notLocked = false;
        }
    }
    bool HTShot = false;
        public void DealDamage()
    {
        targetSprite = target.GetComponent<SpriteRenderer>();
        /*if(targetSprite == null)
            targetSprite = target.GetComponentInChildren<SpriteRenderer>();*/

        targetHealth = target.GetComponent<Health>();
        targetAlien = target.GetComponent<AlienScript>();
        ShieldScript = target.GetComponent<ShieldScript>();
        targetWaypoints = target.GetComponent<Waypoints>();
        
        if (HeavyTurret)
        HTShot = true;


        if (SlowerTurret)
        {
            if (targetHealth.AlienEnemy && targetAlien.InvinclibleEnabled)
            {
                //Debug.Log("Nema");
            }
            else
            {
                targetWaypoints.SlowingCooldown = 5f;
                targetWaypoints.SlowingCooldown = CurrentSlowingCooldown;
                StartCoroutine(ToxicWait());
            }
           /* if (Waypoints.SlowingCooldown > 0)
            {
                targetWaypoints.moveSpeed = 0.5f;
            }*/
        }
        if (LaserTurret)
        {
                StartCoroutine(FlashedRed());
        }
        if (ToxicTurret)
        {
            if (targetHealth.AlienEnemy && targetAlien.InvinclibleEnabled)
            {
                //Debug.Log("Nema");
            }
            else
            {
                targetHealth.ToxicCooldown = 7f;
                targetHealth.ToxicDamage = CurrentToxicDamage;
                StartCoroutine(ToxicWait());
            }


        }
        if (Bullet.trigger)
        {
            //Deal damage indicator
            //targetHealth.EnemyHealth -= Damage;
            Bullet.trigger = false;
            return;
        }
        
    }
    private void EnemyFollow()
    {
        
        if (target != null && !HeavyTurret)
        {
            vectorToTarget = target.transform.position - Cannon.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            Cannon.transform.rotation = Quaternion.Slerp(Cannon.transform.rotation, q, Time.deltaTime * rotationSpeed);
            /*if (ToxicTurret)
            {
                StartCoroutine(ToxicWait());
            }*/
        }
    }
    IEnumerator ToxicWait()
    {
        yield return new WaitForSeconds(0.2f);
        target = null;
    }
   /* public LayerMask targetLayer;
    public float range = 2f;
    public GameObject[] targets; // array of potential targets
    void GetTarget()
    {
        // Find all enemies within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Iterate through enemies to find the last one that entered the range
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= Range / 3.5f)
            {
                target = enemy.transform;
                break;
            }
        }
    }*/
    private void Update()
    {
        //GetTarget();
        if (target != null && Vector2.Distance(transform.position, target.position) > Range * 0.55f && !HeavyTurret)
        {
            // If target is out of range, set target to null
            //target.GetComponent<SpriteRenderer>().color = Color.white;
            target = null;
        }
        if (HeavyTurret)
        {
            StartCoroutine(HTshot());
            

        }
        if (fireCountdown <= 0f && target != null)
        {
            Shoot();
            DealDamage();
            fireCountdown = 1f / fireRate;
            
        }
        fireCountdown -= Time.deltaTime;
        Attack();
        Additional();
        EnemyFollow();
    }
    
    void Shoot()
    {
        
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.ToxicTurret = ToxicTurret;
        bullet.NormalTurret = NormalTurret;
        bullet.FastTurret = FastTurret;
        bullet.SlowerTurret = SlowerTurret;
        bullet.HeavyTurret = HeavyTurret;
        bullet.LaserTurret = LaserTurret;
        bullet.lvl4 = GetComponentInParent<TurretUpgradeMenu>().lvlFour;
        if(!LaserTurret && !Test)
        {
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
        if (LaserTurret)
        {
            FindObjectOfType<AudioManager>().Play("Laser");
        }


        bullet.Damage = Damage;
        if (SpecialTurret)
        {
            scndBullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            bullet2 = scndBullet.GetComponent<Bullet>();
        }
        TurretUMenuScript = this.transform.parent.parent.GetComponent<TurretUpgradeMenu>();
        
        if (TurretUMenuScript != null)
        {
            if (SlowerTurret && TurretUMenuScript.lvlFour)
            {
                bullet.CurrentSlowingCooldownBullet = CurrentSlowingCooldown;
                //bullet.SlowerTurret = true;
            }
        }
        if(bullet != null)
        {
            if (HeavyTurret && !notLocked)
            {
                bullet.Seek(endPoint);
            }
            if(SpecialTurret)
            {
                bullet2.Seek(endPoint);
                bullet2.SpecialTurret = true;
            }

            if(!HeavyTurret)
                bullet.Seek(target);
        }
    }

        private void Attack()
    {
          if (target == null && targetQueue.Count > 0)
        
            {
                //aiming following
                if (!ToxicTurret && fireCountdown < 0f)
                {
                    fireCountdown = 0.1f;
                }
                target = targetQueue.Dequeue();
            }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {

                list.Add(collision.gameObject);
                targetQueue.Enqueue(collision.GetComponent<Transform>());
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            list.Remove(collision.gameObject);

            //target = null;
        }

    }
    public bool IKAShot = false;
    IEnumerator HTshot()
    {
        if (HTShot && !notLocked && list != null) { 
            foreach (var objects in list)
        {

            HTEnemy = objects.GetComponent<Health>();
            HTEnemyShield = objects.GetComponent<ShieldScript>();
            HTEnemyAlien = objects.GetComponent<AlienScript>();

                if (HTEnemy.AlienEnemy && HTEnemyAlien.InvinclibleEnabled)
                {
                    //Debug.Log("Invincible");
                }
                else
                {
                    if (HTEnemy.ShieldEnemy && !HTEnemyShield.NoShield)
                    {

                            //DamagePopup.Create(HTEnemy.transform.position, Damage.ToString());
                            HTEnemyShield.ShieldAmount -= Damage;

                    }
                    else
                    {
                            //DamagePopup.Create(HTEnemy.transform.position, Damage.ToString());
                            HTEnemy.EnemyHealth -= Damage;

                    }
                }


            }
        }
        if (instaKillScript != null && HTShot && !notLocked)
        {
            instaKillScript = GameObject.Find("HT Boost").GetComponent<TurretBoosts>();
            if (instaKillScript.instaKill > 0 && HeavyTurret && !IKAShot)
            {
                foreach (var objects in list)
                {

                    HTEnemy = objects.GetComponent<Health>();
                    HTEnemyShield = objects.GetComponent<ShieldScript>();
                    HTEnemyAlien = objects.GetComponent<AlienScript>();


                    if (HTEnemy.AlienEnemy && HTEnemyAlien.InvinclibleEnabled)
                    {
                        //Debug.Log("Invincible");
                    }
                    else
                    {
                        if (HTEnemy.ShieldEnemy && !HTEnemyShield.NoShield)
                        {

                                HTEnemyShield.ShieldAmount -= 99999999f;

                        }
                        else
                        {
                                HTEnemy.EnemyHealth -= 99999999f;
                        }
                    }
                }
                IKAShot = true;
                instaKillScript.instaKill--;
            }
        }
        HTShot = false;
        yield return new WaitForSeconds(0.1f);
    }
    public IEnumerator FlashedRed()
    {
        if (targetSprite != null)
        {
            targetSprite.color = Color.black;

            yield return new WaitForSeconds(0.03f);
        }
            if (targetSprite != null)
            {
                targetSprite.color = Color.white;
            }
        
    }
}
