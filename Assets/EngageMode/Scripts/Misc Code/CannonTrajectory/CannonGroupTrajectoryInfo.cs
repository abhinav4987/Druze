using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGroupTrajectoryInfo : MonoBehaviour
{
    public struct CannonGroupParams
    {
        public Vector3 centerPosition;
        public Transform transform;
        public float width;
    }

    private CannonGroupParams[] cannonGroupTrajectoryInfo;

    private CannonTrajectoryMarker trajectoryMarker;

    private GameObject trajectoryObject;
    private Hull hull;

    public float timeUnit = 0.1f, endSizeModifier = 0.35f, yDiff = 1.0f;
    public Material meshMaterial;

    private int closestIndex = -1;
    public void InitializeGroupTrajectoryInfo(int size)
    {
        cannonGroupTrajectoryInfo = new CannonGroupParams[size];
    }

    public void SetCannonGroupTrajectoryInfo(int index, CannonGroupParams value)
    {
        cannonGroupTrajectoryInfo[index] = value;
    }

    public int FindClosestGroupIndex()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        int closestIndex = 0, i = 0;
        float maxDot = -1.0f;
        foreach (CannonGroupParams groupParams in cannonGroupTrajectoryInfo)
        {
            float dotProduct = Vector3.Dot(cameraForward, groupParams.transform.forward);
            if(dotProduct >= maxDot)
            {
                maxDot = dotProduct;
                closestIndex = i;
            }
            i++;
        }

        return closestIndex;
    }

    private void Start()
    {
        hull = GetComponentInChildren<Hull>();
        trajectoryObject = new GameObject("Trajectory Object");
        trajectoryMarker = trajectoryObject.AddComponent<CannonTrajectoryMarker>();
        
        trajectoryObject.transform.SetParent(hull.gameObject.transform);

        CannonTrajectoryMarker.StaticHelperValues staticVal = new CannonTrajectoryMarker.StaticHelperValues() { yDiff = yDiff };
        trajectoryMarker.SetStaticParameters(timeUnit, endSizeModifier, staticVal, meshMaterial);
    }

    public void ConstructTrajectoryObject()
    {
        closestIndex = FindClosestGroupIndex();
        trajectoryObject.transform.localPosition = cannonGroupTrajectoryInfo[closestIndex].centerPosition;
        trajectoryObject.transform.localRotation = cannonGroupTrajectoryInfo[closestIndex].transform.localRotation;

        Debug.DrawRay(cannonGroupTrajectoryInfo[closestIndex].centerPosition, Vector3.up, Color.green, Time.deltaTime);

        CannonTrajectoryMarker.VariableParams varParams = new CannonTrajectoryMarker.VariableParams() { initialSpeed = hull.GetCannonInitialSpeed(), angle = hull.GetCannonAngle() };
        trajectoryMarker.SetVariableParameters(cannonGroupTrajectoryInfo[closestIndex].width, varParams);

        trajectoryMarker.CreateTrajectory();
    }

    public void ClearMesh()
    {
        trajectoryMarker.ClearMesh();
    }
}
