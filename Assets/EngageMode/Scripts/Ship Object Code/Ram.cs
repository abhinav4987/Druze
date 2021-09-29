using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ram : MonoBehaviour, IDamageHandler
{
    [SerializeField]
    private float maxDamage;
    private float prevCollisionTime = 0;
    public float GetMaxDamage()
    {
        return maxDamage;
    }

    public void SetMaxDamage(float maxDamage)
    {
        this.maxDamage = maxDamage;
    }

    public float GetDamage()
    {
        return maxDamage;
    }

    public float GetPrevCollisionTime()
    {
        return prevCollisionTime;
    }

    public void Damage(float damageValue)
    {
        GetComponentInParent<Hull>().Damage(damageValue);
    }

    private void FixedUpdate()
    {
        prevCollisionTime += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageHandler damageHandler = collision.gameObject.GetComponent<IDamageHandler>();
        if(damageHandler != null)
        {
            Debug.Log("Ram collided");
            damageHandler.Damage(GetDamage());
            prevCollisionTime = 0;
        }
    }
}
