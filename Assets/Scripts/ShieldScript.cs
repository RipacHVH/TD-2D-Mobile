using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject Shield;
    public float ShieldAmount = 100f;
    public float ShieldMax = 100f;
    public bool NoShield = false;
    public ShieldBar ShieldBar;


    //public HealthBar ShieldBar;
    void Start()
    {
        ShieldAmount = ShieldMax;
    }
    void Update()
    {
        ShieldBar.SetShield(ShieldAmount, ShieldMax);
        
        if  (ShieldAmount <= 0f)
        {
            NoShield = true;
            Destroy(Shield);
        }
    }
}
