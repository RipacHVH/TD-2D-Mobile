using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public bool ToxicTurret;
    public bool SlowerTurret;
    public bool LaserTurret;
    public bool SpecialTurret;
    public bool NormalTurret;
    public bool FastTurret;
    public bool HeavyTurret;

    public bool lvl4;

    Turret turret;
    public float speed = 70f;
    /*public GameObject impactEffect;*/
    public static bool trigger = false;
    TurretBoosts SlowBoostScript;
    Vector3 dir;
    float distanceThisFrame;
    Vector3 dir2;
    float distanceThisFrame2;

    public float destroyDistance = 0.1f; // the distance at which to destroy the object
    public SpriteRenderer targetSprite;
    public Health targetHealth;
    public AlienScript targetAlien;
    public ShieldScript ShieldScript;
    public Waypoints targetWaypoints;
    public float Damage;
    float distance;
    private void Start()
    {
        trigger = false;
        if (SlowBoostScript == null)
        SlowBoostScript = GameObject.Find("Slow Splash").GetComponent<TurretBoosts>();
    }
    public void Seek(Transform _target)
    {
        target = _target;
        ST();
    }
    void ST()
    {
        dir2 = target.position - transform.position;
        distanceThisFrame2 = speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // calculate the distance between the two objects
            distance = Vector2.Distance(transform.position, target.position);
        }
        // if the distance is less than the destroy distance, destroy this object
        if (distance < destroyDistance)
        {
            HitTarget();
            Destroy(gameObject);
        }



        if (target == null)
        {
            
            Destroy(gameObject);
            return;
        }
        dir = target.position - transform.position;
        distanceThisFrame = speed * Time.deltaTime;
        /*if (dir.magnitude <= distanceThisFrame)
        {
            Debug.Log("stana");
            HitTarget();
        }*/
        /*if(!SpecialTurret)
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);*/

        if (SpecialTurret) {
            transform.Translate(dir2.normalized * distanceThisFrame2, Space.World);
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.15f);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Health>();
                var Eshield = hitCollider.GetComponent<ShieldScript>();
                var AEnemy = hitCollider.GetComponent<AlienScript>();
                if (enemy)
                {
                    if (enemy.AlienEnemy && AEnemy.InvinclibleEnabled)
                    {
                        //Debug.Log("Nema");
                    }
                    else
                    {
                        if (enemy.ShieldEnemy && !Eshield.NoShield)
                        {
                            Eshield.ShieldAmount -= 300f;

                        }
                        else
                        {
                            enemy.EnemyHealth -= 300f;
                        }
                    }
                }
            }
            Destroy(gameObject, 2f);
            }

    }
    
    public float CurrentSlowingCooldownBullet;
    void HitTarget()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
        if (target != null)
        {
            targetSprite = target.GetComponent<SpriteRenderer>();
            targetHealth = target.GetComponent<Health>();
            targetAlien = target.GetComponent<AlienScript>();
            ShieldScript = target.GetComponent<ShieldScript>();
            targetWaypoints = target.GetComponent<Waypoints>();
        }
        if (!HeavyTurret && !SlowerTurret)
        {
            
                if (targetAlien != null && targetHealth.AlienEnemy && targetAlien.InvinclibleEnabled )
                {
                    //Debug.Log("Nema");
                }
                else
                {
                    if (ShieldScript != null)
                    {
                        if (targetHealth.ShieldEnemy && !ShieldScript.NoShield)
                        {
                            ShieldScript.ShieldAmount -= Damage;
                        }
                        else
                        {
                            if (targetHealth != null)
                                targetHealth.EnemyHealth -= Damage;
                        }
                    }
                    else
                    {
                        if(targetHealth !=null)
                        targetHealth.EnemyHealth -= Damage;
                    }
                }
            
            /*if (!LaserTurret && !ToxicTurret)
            {
                if (SlowerTurret && targetHealth.BirdEnemy)
                {

                    //DamagePopup.Create(target.transform.position, Damage.ToString("Miss"));
                    Debug.Log("Miss");
                }
                else
                {
                    //DamagePopup.Create(target.transform.position, Damage.ToString());
                }
            }*/
        }






        if (SlowBoostScript != null)
        {
            SlowBoostScript = GameObject.Find("Slow Splash").GetComponent<TurretBoosts>();
            if (SlowBoostScript.SplashSlow && SlowerTurret && lvl4)
            {
                var splashAnim = Instantiate(GameAssets.i.Splash, transform.position, Quaternion.identity);
                Destroy(splashAnim, 1.1f);
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
                foreach (var hitCollider in hitColliders)
                {
                    var enemy = hitCollider.GetComponent<Waypoints>();
                    if (enemy)
                    {
                        
                        enemy.SlowingCooldown = 14f;
                        //enemy.SlowingCooldown = CurrentSlowingCooldownBullet;

                    }
                }
                SlowerTurret = false;

            }
        }
        /*GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);*/
        
        //Destroy(gameObject);

    }
}
