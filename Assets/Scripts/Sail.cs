using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sail : MonoBehaviour
{
    private int sailLevel;

    [SerializeField]
    private int maxSailLevel;
    [SerializeField]
    private float sailHealth;
    [SerializeField]
    private float maxSailSpeed;

    public float getSailHealth()
    {
        return sailHealth;
    }

    public void setSailHealth(float sailHealth)
    {
        this.sailHealth = Mathf.Max(sailHealth, 0.0f);
    }

    public float getMaxSailSpeed()
    {
        return maxSailSpeed;
    }

    public void setMaxSailSpeed(float maxSailSpeed)
    {
        this.maxSailSpeed = maxSailSpeed;
    }

    public int getSailLevel()
    {
        return sailLevel;
    }

    public float getSailLevelNormalized()
    {
        return (float)(sailLevel) / maxSailLevel;
    }

    private void setSailLevel(float sailLevel)
    {
        this.sailLevel = (int)Mathf.Clamp(sailLevel, 0, maxSailLevel);
    }

    public void Damage(float damageAmount)
    {
        setSailHealth(sailHealth - damageAmount);
    }

    public float getCurrentSpeed()
    {
        return Mathf.Lerp(0.0f, maxSailSpeed, getSailLevelNormalized());
    }

    public void changeSailLevel(bool increment = true)
    {
        int changeAmt = (increment) ? 1 : -1;
        setSailLevel(sailLevel + changeAmt);
    }

    private void Awake()
    {
        sailLevel = 0;
    }

}
