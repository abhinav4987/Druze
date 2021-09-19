using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAIActionControls : MonoBehaviour
{
    [SerializeField]
    private Hull hull;

    [SerializeField]
    private float angleChangeSpeed = 5f;
    
    private void Start()
    {
        hull = GetComponentInChildren<Hull>();
    }

    public void IncreaseSail()
    {
        hull.shipSail.ChangeSailLevel(increment: true);
    }

    public void DecreaseSail()
    {
        hull.shipSail.ChangeSailLevel(increment: false);
    }

    public void SetSailLevel(int sailLevel)
    {
        int currSailLevel = hull.shipSail.GetSailLevel();
        if (currSailLevel > sailLevel)
            DecreaseSail();
        else if (currSailLevel < sailLevel)
            IncreaseSail();
    }

    public void TurnLeft()
    {
        hull.RotateHull(leftRotate: true);
    }

    public void TurnRight()
    {
        hull.RotateHull(leftRotate: false);
    }

    private void ChangeCannonAngle(float angleUnit)
    {
        hull.ChangeCannonAngle(increment: angleUnit);
    }

    public void IncreaseCannonAngle()
    {
        float angleIncrement = angleChangeSpeed * Time.deltaTime;
        ChangeCannonAngle(angleIncrement);
    }
    public void DecreaseCannonAngle()
    {
        float angleDecrement = angleChangeSpeed * Time.deltaTime;
        ChangeCannonAngle(-angleDecrement);
    }

    public void FireCannon(int cannonGroupIndex)
    {
        hull.FireCannons(groupIndex: cannonGroupIndex);
    }

    public void ExtremeRotation(bool leftDir)
    {
        float turnSpeedModifier = 2f;
        hull.RotateHull(leftRotate: leftDir, modifierValue: turnSpeedModifier);
    }
}

