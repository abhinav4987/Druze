using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class compass : MonoBehaviour
{
    // Start is called before the first frame update

    public Text LocationStatuss;
    public float sensitivity = 15.0f;
    void Start()
    {
        Input.compass.enabled = true;

        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            LocationStatuss.text = "not running.";
        }

        StartCoroutine(location());
    }

    IEnumerator location()
    {
        if (!Input.location.isEnabledByUser)
        {
            LocationStatuss.text = "GPS not Enabled";
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            LocationStatuss.text = "Initiallising.";
            maxWait--;
        }

        if (maxWait < 1)
        {
            LocationStatuss.text = "Failed1";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed && !Input.compass.enabled)
        {
            LocationStatuss.text = "failed2";
            yield break;

        }
        else
        {
            InvokeRepeating("Compass", 0.05f, 0.0005f);
            LocationStatuss.text = "all done";
        }

    }

    void Compass()
    {
        LocationStatuss.text = "rotating" + Input.compass.trueHeading.ToString();
        transform.eulerAngles = new Vector3(0, 0, sensitivity * Mathf.FloorToInt(-1*Input.compass.trueHeading / sensitivity));
    }

    // Update is called once per frame
    //void FixedUpdate () {
    // transform.Rotate (0, 0, 20f * Time.deltaTime);
    // LocationStatuss.text = Input.compass.magneticHeading.ToString()+" "+Input.compass.rawVector.ToString();
    // transform.eulerAngles = new Vector3(0, 0, 20);
    //}
}