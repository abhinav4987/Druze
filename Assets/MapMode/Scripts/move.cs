using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class move : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitudeValue;
    public Text longitudeValue;
    public float lastLatitude;
    public float lastLongitude;
    public float dif1;
    public float dif2;
    public Text dift1;
    public Text dift2;
    public float max1;
    public float max2;
    public Text altitudeValue; 
    public Text horizontalAccuracyValue;
    public Text timestampValue;
    public Vector2 speed = new Vector2(5,5);
    // Start is called before the first frame update
    void Start()
    {
        GPSStatus.text = "Running not";
        if (!Permission.HasUserAuthorizedPermission (Permission.FineLocation))
        {
                Permission.RequestUserPermission (Permission.FineLocation);
        }
        
        StartCoroutine(GPSLoc());
    }

    IEnumerator GPSLoc()
    {
        if(!Input.location.isEnabledByUser) {
            GPSStatus.text = "GPS not Enabled";
            yield break;
        }

        Input.location.Start(0.2f,0.2f);
    
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait < 1) {
            GPSStatus.text = "Time Out.";
            yield break;
        }
        
        if(Input.location.status == LocationServiceStatus.Failed) {
            GPSStatus.text = "Connection Failed";
            yield break;
        } else {
            // granted
            GPSStatus.text = "Running";
            lastLatitude = 0;
            lastLongitude = 0;
            max1 = -10000000000000000;
            max2 = -10000000000000000;
            InvokeRepeating("UpdateGPSData",0.05f,0.00005f);
        }

    }


    private void UpdateGPSData() {
        if(Input.location.status == LocationServiceStatus.Running) {
            // Access granted to GPS values and it has been init
            GPSStatus.text = "Running";

            

            float newLattitude = Input.location.lastData.latitude;
            float newLongitude = Input.location.lastData.longitude;
            if(lastLongitude != 0 && lastLatitude != 0) {

                dif1 = 100000*(newLattitude-lastLatitude);
                dif2 = 100000*(lastLongitude-newLongitude);
                
                if(Mathf.Abs(dif1) > max1){
                    dift1.text = dif1.ToString();
                    max1 = dif1;
                }

                if(Mathf.Abs(dif2) > max2){
                    dift2.text = dif2.ToString();
                    max2 = dif2;
                }
                transform.Translate(dif2*Time.deltaTime,dif1*Time.deltaTime,0);
                // transform.Translate(0.2f*Time.deltaTime,0f,0f);
            }
            
            lastLatitude = newLattitude;
            lastLongitude = newLongitude;
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();


        } else {
            // service is stopped
            GPSStatus.text = "Not Running";
        }
    // Update is called once per frame
    }
}
