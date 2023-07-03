using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Enemy targetEnemy;
    public void SetTarget(Enemy targetEnemy)
    {
        this.targetEnemy = targetEnemy;
        Debug.Log(targetEnemy);
    }
}
