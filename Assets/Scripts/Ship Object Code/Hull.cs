using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hull : MonoBehaviour
{

    private Rigidbody rb;

    public GameObject cannonPrefab;
    [System.Serializable]
    public struct CannonLocations
    {
        public Transform[] locations;
    }

    public CannonLocations[] cannonLocationGroup;

    private struct CannonGroup
    {
        public Cannon[] cannons;
    }

    [SerializeField]
    private float healthPoint;
    
    private float currentSpeed = 0;
    private float defence;

    [SerializeField]
    private float turnSpeed;

    CannonGroup[] shipCannonGroups;

    public Sail shipSail;
    Ram shipRam;

    public float GetCurrentSpeed() {
        return currentSpeed;
    }

    public void SetCurrentSpeed(float newSpeed) {
        currentSpeed = newSpeed;
    }

    public float GetHealthPoint() {
        return healthPoint;
    }

    public void SetHealthPoint(int newHealthPoint) {
        healthPoint = newHealthPoint;
    }

    public void SetCannonAngle(int groupIndex, float angle) {
        foreach(Cannon cannon in shipCannonGroups[groupIndex].cannons)
        {
            cannon.SetAngle(angle);
        }
    }

    public void FireCannons(int groupIndex) {
        foreach (Cannon cannon in shipCannonGroups[groupIndex].cannons)
        {
            cannon.Shoot();
        }
    }

    public void TakeDmage(float damageIncurred) {
        healthPoint -= damageIncurred;
    }

    public void RotateHull(bool leftRotate) {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (leftRotate ? -1.0f : 1.0f) * turnSpeed * Time.deltaTime , 0);
    }

    void UpdateCurrentSpeed () {
        float desiredSpeed = shipSail.GetCurrentSpeed();
        int dir;
        if (currentSpeed <= desiredSpeed)
            dir = 1;
        else
            dir = -1;
        currentSpeed = Mathf.Clamp(currentSpeed + dir * shipSail.GetAcceleration() * Time.deltaTime, 0, desiredSpeed);
        rb.velocity = currentSpeed * transform.right;
    }


    void FixedUpdate()
    {
        UpdateCurrentSpeed();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InitializeCannons();
        shipSail = GetComponentInChildren<Sail>();
        shipRam = GetComponentInChildren<Ram>();
    }

    private void InitializeCannons()
    {
        shipCannonGroups = new CannonGroup[cannonLocationGroup.Length];
        int i = 0;
        foreach (CannonLocations cannonLocation in cannonLocationGroup)
        {
            int j = 0;
            shipCannonGroups[i].cannons = new Cannon[cannonLocation.locations.Length];
            foreach (Transform location in cannonLocation.locations)
            {
                shipCannonGroups[i].cannons[j++] = Instantiate(cannonPrefab, location.position, location.rotation, transform).GetComponentInChildren<Cannon>();
            }
            i++;
        }
    }
}







