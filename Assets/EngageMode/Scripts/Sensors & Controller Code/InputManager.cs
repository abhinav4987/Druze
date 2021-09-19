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

    void Start()
    {
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
        hull.SetCannonAngle(value);
    }

    public void IncreaseSailLevel()
    {
        hull.shipSail.ChangeSailLevel(increment: true);
    }

    public void DecreaseSailLevel()
    {
        hull.shipSail.ChangeSailLevel(increment: false);
    }

    public void ShootLeftCannon()
    {
        hull.FireCannons(0);
    }

    public void ShootRightCannon()
    {
        hull.FireCannons(1);
    }

    private void FixedUpdate()
    {
        if (isRotating)
            hull.RotateHull(leftRotate: isLeftDirection);
    }
}
