using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoverScript : MonoBehaviour
{

    public Vector3 targetPosition;

    void Update()
    {
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
    }
}
