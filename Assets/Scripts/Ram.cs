using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour
{
    private float maxDamage;

    public float getMaxDamage()
    {
        return maxDamage;
    }

    public void setMaxDamage(float maxDamage)
    {
        this.maxDamage = maxDamage;
    }

    public float DamageObject(float currSpeed)
    {
        return Mathf.Lerp(0.0f, maxDamage, currSpeed);
    }
}
