using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    private float reloadTime;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void shoot()
    {
        StartCoroutine(Reload());


    }
   
    IEnumerator Reload()
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(reloadTime);

        //Do the action after the delay time has finished.
    }
    void setAngle()
    {

    }
    public int getreloadTime()
    {
        return reloadTime;
    }
    public int setreloadTime(int reloadTime)
    {
        this.reloadTime = reloadTime;
    }
    public int getAngle()
    {
        return angle;
    }
    public int setAngle(float angle)
    {
        this.angle = angle;
    }
}
