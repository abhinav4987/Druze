using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{

    public ParticleSystem smokePS;

    private bool reloaded = true;

    private float remaningReloadTime = 0;

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
            remaningReloadTime = reloadTime;
            Instantiate(smokePS, cannonBallLocation.position, cannonBallLocation.rotation);
            StartCoroutine(Reload());
        }
    }

    private void DecreaseTimeVal()
    {
        remaningReloadTime = Mathf.Max(remaningReloadTime - Time.deltaTime, 0);
    }
   
    IEnumerator Reload()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            DecreaseTimeVal();
            if (remaningReloadTime == 0)
                break;
        }
        reloaded = true;
        yield return null;
    }

    public bool IsCannonReady()
    {
        return reloaded;
    }

    public float GetNormalizedRemaningTime()
    {
        return remaningReloadTime / reloadTime;
    }

    public float GetRemaningTime()
    {
        return remaningReloadTime;
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
        Transform[] transforms = GetComponentsInChildren<Transform>();
        cannonBallLocation = transforms[transforms.Length - 1];
    }
}
