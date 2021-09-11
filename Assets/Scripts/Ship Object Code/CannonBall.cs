using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonBall : MonoBehaviour
{

    private float damage;
    
    public float GetDamage()
    {
        return damage;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
