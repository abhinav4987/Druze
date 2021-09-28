using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{

    private bool reloaded = true;

    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private float initialSpeed = 50f;

    private float angleNormalizedValue = 0;

    [SerializeField]
    private float maxAngle = 45;

    public GameObject cannonBall;

    private Transform cannonBallLocation = null;
    public void Shoot()
    {
        if(reloaded && cannonBallLocation != null)
        {
            reloaded = false;
            Rigidbody rb = Instantiate(cannonBall, cannonBallLocation.position, cannonBallLocation.rotation).GetComponent<Rigidbody>();
            rb.velocity = cannonBallLocation.forward * initialSpeed;
            StartCoroutine(Reload());
        }
    }
   
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }

    public bool IsCannonReady()
    {
        return reloaded;
    }

    public float GetInitialSpeed()
    {
        return initialSpeed;
    }

    public void SetInitialSpeed(float initialSpeed)
    {
        this.initialSpeed = initialSpeed;
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

    public float GetMaxAngle()
    {
        return maxAngle;
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

    private void Start()
    {
        cannonBallLocation = GetComponentsInChildren<Transform>()[1];
    }
}
