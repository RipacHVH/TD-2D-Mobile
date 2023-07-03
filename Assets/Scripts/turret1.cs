using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret1 : MonoBehaviour
{
    [SerializeField] private float range;
    private Turret turret;

    private void Awake()
    {
         turret = GetComponent<Turret>();
    }
    private void Update()
    {
        turret.DealDamage();
    }
}
