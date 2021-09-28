using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CannonTrajectoryMarker : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    Vector2[] uvs;
    int[] triangles;

    Vector3[] trajectoryPoints;

    public float timeUnit;
    public float width;
    public float endSizeModifier = 0.8f;

    [System.Serializable]
    public struct VariableParams
    {
        public float initialSpeed;
        public float angle;
    }

    [System.Serializable]
    public struct StaticHelperValues
    {
        public float yDiff;

        public float GetDiffYG()
        {
            return yDiff / Physics.gravity.magnitude; ;
        }
    }

    public void SetStaticParameters( float timeUnit, float endSizeModifier, StaticHelperValues staticVal, Material meshMaterial)
    {
        this.timeUnit = timeUnit;
        this.endSizeModifier = endSizeModifier;
        this.staticVal = staticVal;
        GetComponent<MeshRenderer>().material = meshMaterial;
    }

    public void SetVariableParameters(float width, VariableParams varParams)
    {
        this.width = width;
        this.varParams = varParams;
    }

    void Awake()
    {
        mesh = new Mesh();
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; 
    }

    float GetTotalTime(float verticalSpeed, StaticHelperValues staticVal)
    {
        float alpha = verticalSpeed / Physics.gravity.magnitude;

        return alpha + Mathf.Sqrt(alpha * alpha + staticVal.GetDiffYG());
    }

    void CalculateTrajectoryPoints(VariableParams varParams, StaticHelperValues staticVal)
    {
        float horizontalSpeed = varParams.initialSpeed * Mathf.Cos(varParams.angle * Mathf.Deg2Rad),
            verticalSpeed = varParams.initialSpeed * Mathf.Sin(varParams.angle * Mathf.Deg2Rad);

        float totalTime = GetTotalTime(verticalSpeed, staticVal);
        int n = Mathf.CeilToInt(totalTime / timeUnit);

        trajectoryPoints = new Vector3[n];
        trajectoryPoints[0] = Vector3.zero;


        for (int i=1;i<n-1;i++)
        {
            float x = horizontalSpeed * timeUnit * i, y = (verticalSpeed - 0.5f * Physics.gravity.magnitude * timeUnit * i) * timeUnit * i;
            trajectoryPoints[i] = new Vector3(0, y, x);
        }

        Vector3 lastOffset = new Vector3(0, (verticalSpeed - 0.5f * Physics.gravity.magnitude * totalTime) * totalTime, horizontalSpeed * totalTime);

        trajectoryPoints[n - 1] = lastOffset;
    }

    void CalculateMeshInfo()
    {
        int points = trajectoryPoints.Length;
        int vertCount = 2 * points;
        int triangleCount = (points - 1) * 4;

        vertices = new Vector3[vertCount];
        uvs = new Vector2[vertCount];
        triangles = new int[3 * triangleCount];

        Vector3 widthOffset = Vector3.right * width;
        float endWidth = endSizeModifier * width;

        vertices[0] = trajectoryPoints[0] + widthOffset * 0.5f;
        vertices[1] = trajectoryPoints[0] - widthOffset * 0.5f;

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);

        for (int i = 0, p = 1; i < triangleCount; i += 4, p++)
        {
            widthOffset = Vector3.right * Mathf.Lerp(width, endWidth, (float)p / (points - 1));
            int p2 = 2 * p;

            vertices[p2] = trajectoryPoints[p] + widthOffset * 0.5f;
            vertices[p2 + 1] = trajectoryPoints[p] - widthOffset * 0.5f;


            uvs[p2] = new Vector2(0, p / (points - 1));
            uvs[p2+1] = new Vector2(1, p / (points - 1));

            triangles[i * 3] = p2 - 2;
            triangles[i * 3 + 1] = p2;
            triangles[i * 3 + 2] = p2 + 1;

            triangles[i * 3 + 3] = p2 + 1;
            triangles[i * 3 + 4] = p2 - 1;
            triangles[i * 3 + 5] = p2 - 2;

            triangles[i * 3 + 6] = p2 - 2;
            triangles[i * 3 + 7] = p2 + 1;
            triangles[i * 3 + 8] = p2;

            triangles[i * 3 + 9] = p2 + 1;
            triangles[i * 3 + 10] = p2 - 2;
            triangles[i * 3 + 11] = p2 - 1;
        }

        UpdateMeshInfo();
    }

    void UpdateMeshInfo()
    {
        ClearMesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.uv = uvs;
    }

    private VariableParams varParams;
    private StaticHelperValues staticVal;

    public void CreateTrajectory()
    {
        CalculateTrajectoryPoints(varParams, staticVal);
        CalculateMeshInfo();
    }

    public void ClearMesh()
    {
        mesh.Clear();
    }
}
