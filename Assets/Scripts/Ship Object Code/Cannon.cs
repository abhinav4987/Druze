using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    private float angleNormalizedValue = 0;

    [SerializeField]
    private float maxAngle = 45;
    public void Shoot()
    {
        StartCoroutine(Reload());
    }
   
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
    }
    public float GetReloadTime()
    {
        return reloadTime;
    }
    public void SetReloadTime(float reloadTime)
    {
        this.reloadTime = reloadTime;
    }
    public float GetAngle()
    {
        return angleNormalizedValue * maxAngle;
    }
    public void SetAngle(float angleNormalizedValue)
    {
        this.angleNormalizedValue = Mathf.Clamp(angleNormalizedValue, 0, 1);
        RotateCannon();
    }
    public void RotateCannon()
    {
        transform.localRotation = Quaternion.Euler(-GetAngle(), 0, 0);
    }
}
