using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{

    private bool gyroActive;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rotation;

    private void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        cameraContainer.transform.SetParent(transform.parent);
        transform.SetParent(cameraContainer.transform);

        gyroActive = EnableGyro();
    }

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0);
            rotation = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    private void Update()
    {
        if(gyroActive)
        {
            transform.localRotation = gyro.attitude * rotation;
        }
    }
}
