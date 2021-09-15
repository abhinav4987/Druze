using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAIActionControls : MonoBehaviour
{
    private Hull hull;
    void Start()
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
        float angleIncrementUnit = 0.5f;
        ChangeCannonAngle(angleIncrementUnit);
    }
    public void DecreaseCannonAngle()
    {
        float angleDecrementUnit = 0.5f;
        ChangeCannonAngle(-angleDecrementUnit);
    }

    public void FireCannon(int cannonGroupIndex)
    {
        hull.FireCannons(groupIndex: cannonGroupIndex);
    }


}

