using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Hull : MonoBehaviour, IDamageHandler
{

    private Rigidbody rb;

    public GameObject cannonPrefab;

    public event EventHandler OnDamage;
    public event EventHandler OnDefeat;

    private bool isCannonBuild = false;

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
    private float maxHealth;
    private float currentHealth;
    
    private float currentSpeed = 0;
    private float defence;

    [SerializeField]
    private float turnSpeed;

    CannonGroup[] shipCannonGroups;

    [HideInInspector]
    public Sail shipSail;
    private Ram shipRam;

    private CannonGroupTrajectoryInfo cannonGroupTrajectoryInfo;

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

    public float GetMaxHealth() {
        return maxHealth;
    }

    public float GetCurrentHealth() {
        return currentHealth;
    }

    public void SetHealthPoint(int newHealthPoint) {
        maxHealth = newHealthPoint;
    }

    public float GetReloadTime(int index)
    {
        return shipCannonGroups[index].cannons[0].GetReloadTime();
    }

    public float GetCurrentReloadTime(int index)
    {
        return shipCannonGroups[index].cannons[0].GetRemaningTime();
    }

    public float GetNormalizedRemainingReloadTime(int index)
    {
        return shipCannonGroups[index].cannons[0].GetNormalizedRemaningTime();
    }

    public float GetMaxCannonAngle()
    {
        return shipCannonGroups[0].cannons[0].GetMaxAngle();
    }

    public void SetCannonAngle(float angle, bool normalized = false)
    {
        if(!normalized)
        {
            float maxAngle = shipCannonGroups[0].cannons[0].GetMaxAngle();
            angle /= maxAngle;
        }
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

    public void Damage(float damageValue) {
        currentHealth = Mathf.Clamp(currentHealth - damageValue,0, maxHealth);
        Debug.Log(currentHealth);
        OnDamage?.Invoke(this, EventArgs.Empty);
        if (GetCurrentHealth() <= 0)
            OnDefeat?.Invoke(this, EventArgs.Empty);
    }

    public void RotateHull(bool leftRotate, float modifierValue = 1)
    {
        rb.AddTorque(0, (leftRotate ? -1.0f : 1.0f) * modifierValue * turnSpeed * Time.deltaTime, 0, ForceMode.Acceleration);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (leftRotate ? -1.0f : 1.0f) * modifierValue * turnSpeed * Time.deltaTime, 0);
    }

    void UpdateCurrentSpeed () {
        float desiredSpeed = shipSail.GetCurrentSpeed();
        if(rb.velocity.magnitude < desiredSpeed)
        {
            Vector3 sailForce = shipSail.GetCurrentAcceleration() * transform.right;
            rb.AddForce(sailForce, ForceMode.Acceleration);
        }
    }


    void FixedUpdate()
    {
        UpdateCurrentSpeed();
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        transform.parent.gameObject.TryGetComponent(out cannonGroupTrajectoryInfo);
        shipTransform = GetComponentInChildren<Transform>();
        rb = GetComponent<Rigidbody>();
        shipSail = GetComponentInChildren<Sail>();
        shipRam = GetComponentInChildren<Ram>();

        InitializeCannons();
    }

    private void InitializeCannons()
    {
        CannonGroupTrajectoryInfo.CannonGroupParams groupParams;
        if (cannonGroupTrajectoryInfo != null)
            cannonGroupTrajectoryInfo.InitializeGroupTrajectoryInfo(cannonLocationGroup.Length);
        shipCannonGroups = new CannonGroup[cannonLocationGroup.Length];
        int i = 0;
        foreach (CannonLocations cannonLocation in cannonLocationGroup)
        {
            int j = 0;
            Vector3 groupMeanPosition = Vector3.zero;

            shipCannonGroups[i].cannons = new Cannon[cannonLocation.locations.Length];

            foreach (Transform location in cannonLocation.locations)
            {
                groupMeanPosition += location.position;
                shipCannonGroups[i].cannons[j++] = Instantiate(cannonPrefab, location.position, location.rotation, transform).GetComponentInChildren<Cannon>();
            }

            groupMeanPosition /= cannonLocation.locations.Length;
            groupMeanPosition = transform.InverseTransformPoint(groupMeanPosition);

            Transform groupTransform = cannonLocation.locations[0];
            float minWidth = 0.2f;
            float width = Mathf.Max(minWidth, Vector3.Distance(cannonLocation.locations[0].position, cannonLocation.locations[cannonLocation.locations.Length - 1].position));

            groupParams = new CannonGroupTrajectoryInfo.CannonGroupParams() { centerPosition = groupMeanPosition, transform = groupTransform , width = width };

            if (cannonGroupTrajectoryInfo != null)
                cannonGroupTrajectoryInfo.SetCannonGroupTrajectoryInfo(i, groupParams);

            i++;
        }

        isCannonBuild = true;
    }

    public bool GetIsCannonBuilt()
    {
        return isCannonBuild;
    }
}







