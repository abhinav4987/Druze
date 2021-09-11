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

    public void SetLeftCannonGroupAngle(float value)
    {
        hull.SetCannonAngle(0, value);
    }

    public void SetRightCannonGroupAngle(float value)
    {
        hull.SetCannonAngle(1, value);
    }

    public void IncreaseSailLevel()
    {
        hull.shipSail.ChangeSailLevel(increment: true);
    }

    public void DecreaseSailLevel()
    {
        hull.shipSail.ChangeSailLevel(increment: false);
    }

    private void FixedUpdate()
    {
        if (isRotating)
            hull.RotateHull(leftRotate: isLeftDirection);
    }
}
