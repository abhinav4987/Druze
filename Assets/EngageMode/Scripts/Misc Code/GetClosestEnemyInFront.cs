using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClosestEnemyInFront : MonoBehaviour
{
    public float threshold = 0.8f;

    [SerializeField]
    private Hull[] enemyHulls;

    private int index = -1;

    [SerializeField]
    private Transform mainCameraTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForward = mainCameraTransform.forward;
        int minIndex = -1, i = 0;
        float maxDot = threshold;
        foreach(Hull hull in enemyHulls)
        {
            Vector3 hullPosition = hull.GetShipTransform().position;
            Vector3 modifiedPosition = new Vector3(hullPosition.x, mainCameraTransform.position.y, hullPosition.z);
            float currentDot = Vector3.Dot(cameraForward, (modifiedPosition - mainCameraTransform.position).normalized);

            if(currentDot >= maxDot)
            {
                minIndex = i;
                currentDot = maxDot;
            }
            i++;
        }

        index = minIndex;
    }

    public HullHealthBarController GetClosestBarController()
    {
        return (index == -1) ? null : enemyHulls[index].GetComponent<HullHealthBarController>();
    }
}
