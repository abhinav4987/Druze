using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sail : MonoBehaviour
{
    private int sailLevel;
    [SerializeField]
    private int maxSailLevel;

    private float sailHealth;
    [SerializeField]
    private float maxSailHealth;

    [SerializeField]
    private float maxSailSpeed;

    [SerializeField]
    private float acceleration;

    public float GetAcceleration()
    {
        return acceleration;
    }

    public void SetAcceleration(float acceleration)
    {
        this.acceleration = Mathf.Max(acceleration, 0.0f);
    }

    public float GetSailHealth()
    {
        return sailHealth;
    }

    public void SetSailHealth(float sailHealth)
    {
        this.sailHealth = Mathf.Max(maxSailHealth, 0.0f);
    }

    public float GetMaxSailHealth()
    {
        return maxSailHealth;
    }

    public void SetMaxSailHealth(float maxSailHealth)
    {
        this.maxSailHealth = maxSailHealth;
    }

    private float GetNormalizedHealth()
    {
        return sailHealth / maxSailHealth;
    }

    public float GetMaxSailSpeed()
    {
        return maxSailSpeed;
    }

    public void SetMaxSailSpeed(float maxSailSpeed)
    {
        this.maxSailSpeed = maxSailSpeed;
    }

    public int GetSailLevel()
    {
        return sailLevel;
    }

    public float GetSailLevelNormalized()
    {
        return (float)(sailLevel) / maxSailLevel;
    }

    private void SetSailLevel(float sailLevel)
    {
        this.sailLevel = (int)Mathf.Clamp(sailLevel, 0, maxSailLevel);
    }

    public void Damage(float damageAmount)
    {
        SetSailHealth(sailHealth - damageAmount);
    }

    public float GetCurrentSpeed()
    {
        return Mathf.Lerp(0.0f, maxSailSpeed * GetNormalizedHealth(), GetSailLevelNormalized());
    }

    public void ChangeSailLevel(bool increment = true)
    {
        int changeAmt = (increment) ? 1 : -1;
        SetSailLevel(sailLevel + changeAmt);
    }

    private void Awake()
    {
        SetSailLevel(0);
        SetSailHealth(maxSailHealth);
    }

}
