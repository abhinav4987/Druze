using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterCode : MonoBehaviour
{
    public Transform targetTransform;

    private float angle = 0;

    private void Update()
    {
        Vector3 targetPosition = targetTransform.position, selfPosition = transform.position;

        float angle = Vector3.Angle(transform.right, targetPosition - selfPosition);
        Debug.Log(angle);
    }

    private void OnDrawGizmos()
    {
        Vector3 targetPosition = targetTransform.position, selfPosition = transform.position;        

        Gizmos.DrawRay(selfPosition, transform.right);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(selfPosition, (targetPosition - selfPosition).normalized);
    }
}
