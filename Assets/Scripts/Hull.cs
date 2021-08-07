using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    float healthPoint;

    
    float defence;

    int cannonColumnsCount = 2;


    Cannons[] shipCannonColumn = new Cannons[cannonColumns];

    
    Sail ShipSail = new ShipSail();



    void takeDmage(float damageIncurred) {
        health -= damageIncurred;
    }

    void setCannonAngle(int cannonColumnIndex, float cannonAngle) {

    }

    void fireCannon(int cannonColumnIndex) {

    }

    void rotateHull(float rotationAngle) {

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}







