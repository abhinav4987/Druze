using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoverScript : MonoBehaviour
{

    public Transform targetTransform;

    void Update()
    {
        Vector3 targetPosition = targetTransform.position;
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
    }
}
