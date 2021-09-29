using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    private Hull hull;

    private bool isRotating;
    private bool isLeftDirection;

    private int index = 0;

    [SerializeField]
    private Transform mainCameraTransform;

    void Start()
    {
        Input.multiTouchEnabled = false;
        isRotating = false;
        isLeftDirection = false;
        hull = ship.GetComponentInChildren<Hull>();
    }

    public void RotateLeft()
    {
        isLeftDirection = true;
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }

    public void RotateRight()
    {
        isLeftDirection = false;
        isRotating = true;
    }

    public void SetCannonAngle(float value)
    {
        hull.SetCannonAngle(value, normalized: true);
    }

    public void ChangeSailLevel(bool increase)
    {
        hull.shipSail.ChangeSailLevel(increment: increase);
    }

    public void IncreaseSailLevel()
    {
        hull.shipSail.ChangeSailLevel(increment: true);
    }

    public void DecreaseSailLevel()
    {
        hull.shipSail.ChangeSailLevel(increment: false);
    }

    public bool GetIsCannonBuilt()
    {
        return hull.GetIsCannonBuilt();
    }

    public float GetReloadTime()
    {
        return hull.GetReloadTime(index);
    }

    public float GetCurrentReloadTime()
    {
        return hull.GetCurrentReloadTime(index);
    }

    public void ShootLeftCannon()
    {
        hull.FireCannons(0);
    }

    public void ShootRightCannon()
    {
        hull.FireCannons(1);
    }

    public void ShootCannon()
    {
        hull.FireCannons(index);
    }

    private void CalculateClosestIndex()
    {
        Vector3 cameraForward = mainCameraTransform.forward;
        int minIndex = 0, i = 0;
        float maxDot = -1;
        foreach( var cannonLocations in hull.cannonLocationGroup)
        {
            float currentDot = Vector3.Dot(cameraForward, cannonLocations.locations[0].forward);
            if ( currentDot > maxDot )
            {
                minIndex = i;
                maxDot = currentDot;
            }
            i++;
        }
        index = minIndex;
    }

    private void Update()
    {
        CalculateClosestIndex();
    }

    private void FixedUpdate()
    {
        if (isRotating)
            hull.RotateHull(leftRotate: isLeftDirection);
    }
}
