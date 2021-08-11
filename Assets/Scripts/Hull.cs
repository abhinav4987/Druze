using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hull : MonoBehaviour
{
    private float healthPoint;
    
    private float currentSpeed;
    float defence;

    int cannonColumnsCount = 2;
    int cannonsPerColumn = 5;

    Cannons[,] shipCannonColumn = new Cannons[cannonColumns, cannonsPerColumn];

    Sail ShipSail = new ShipSail();

    Ram ShipRam = new Ram();

    public float getCurrentSpeed() {
        return currentSpeed;
    }

    public float setCurrentSpeed(float newSpeed) {
        currentSpeed = newSpeed;
    }

    public int getHealthPoint() {
        return healthPoint;
    }

    public void setHealthPoint(int newHealthPoint) {
        healthPoint = newHealthPoint;
    }

    public void setCannonAngle(int columnIndex, float angle) {
        for(int i = 0; i < cannonsPerColumn;i++) {
            shipCannonColumn[columnIndex][i].setAngle(angle); 
        }
    }

    public void fireCannons(int column) {

        for(int i =0;i< cannonsPerColumn;i++) {
            hipCannonColumn[column][i].shoot();
        }
    }


    public void takeDmage(float damageIncurred) {
        health -= damageIncurred;
    }


    public void rotateHull(float rotationAngle) {

    }

    public float getSailSpeed() {
        return ShipSail.getSailSpeed();
    }


    void UpdateCurrentSpeed () {
        
        if(ShipSail.getSailSpeed() != currentSpeed) {
            float diff = currentSpeed - ShipSail.getSailSpeed();
            if(diff == 1) {
                setCurrentSpeed(ShipSail.getSailSpeed());
            } else {
                setCurrentSpeed(currentSpeed + diff/2);
            }
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        UpdateCurrentSpeed();
    }
}







