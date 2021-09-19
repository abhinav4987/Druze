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

    [HideInInspector]
    public Sail shipSail;
    private Ram shipRam;

    private Transform shipTransform;

    public Transform GetShipTransform()
    {
        return shipTransform;
    }

    public float GetPrevCollisionTime()
    {
        return shipRam.GetPrevCollisionTime();
    }

    public float GetTurnSpeed()
    {
        return turnSpeed;
    }

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

    public void SetCannonAngle(float angle)
    {
        foreach (CannonGroup cannonGroup in shipCannonGroups)
        {
            foreach (Cannon cannon in cannonGroup.cannons)
            {
                cannon.SetAngle(angle);
            }
        }
    }

    public float GetCannonAngle()
    {
        return shipCannonGroups[0].cannons[0].GetAngle();
    }

    public float GetCannonInitialSpeed()
    {
        return shipCannonGroups[0].cannons[0].GetInitialSpeed();
    }

    public bool GetCannonGroupReady(int groupIndex)
    {
        return shipCannonGroups[groupIndex].cannons[0].IsCannonReady();
    }

    public void ChangeCannonAngle(float increment)
    {
        SetCannonAngle(GetCannonAngle() + increment);
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

    public void RotateHull(bool leftRotate, float modifierValue = 1)
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (leftRotate ? -1.0f : 1.0f) * modifierValue * turnSpeed * Time.deltaTime, 0);
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
        shipTransform = GetComponentInChildren<Transform>();
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







