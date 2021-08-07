using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{


    // i will write here only
    // so this is a class named Hull
    // THIS  CLASS WILL IMITATE A REAL WORLD OBJECT 
    // TAHT REAL WORL OBJECT IS A ship

    // now a thing to remember is
    // real world objects have two things
    // first are some properties 
    // in your case your age, your height, you skin color are properties 
    // APART FROM PROPERTIES REAL WORLD OBJECTS ALSO HAVE SOME FINCTIONS
    // LIKE YOUR FUNCTION WILL BE SLEEPING, EATING, STUDYING, FIGHTING, NOT LOVING, PLAYING,ETC
    // so in order to imitatet that CLASSES ALSO HAVE FUNCTIONS

    // NOW WE WILL LOOK AT THE EXAMPLE




    // THIS IS A PROPERTY WHICH TELL THE SHIP HEALTH 
    float healthPoint;

    // THIS PROPERTY TELLS THE DEFENCE LEVEL OF THE SHIP
    float defence;

    // THIS PROPERTY TELLS THE CANNON SLOTS FOR A SHIP
    int cannonColumnsCount = 2;
    // 0 -> left Cannons
    // 1 -> right Cannons

    // AND THESE ARE THE CANNONS


    // A THING TO NOTICE CANNONS ARE THEMSELVES A CLASS HAVING THEIR OWN PROPERTIES AND FUNCTIONS
    Cannons[] shipCannonColumn = new Cannons[cannonColumns];

    // AND THIS IS A SAIL USED TO CONTROL THE SPEED OF THE SHIP
    // THIS IS ALSO A CLASS IN ITLSELF
    Sail ShipSail = new ShipSail();





    // NOW AS I TALKED ABOUT PREVIOUSLY
    // THE FOLLOWING ARE THE FUNTIONS THAT THE SHIP CAN DO


    // THIS METHODS TWLL THE DAMAGE WHEN IT HITS SOMETHING
    void takeDmage(float damageIncurred) {
        health -= damageIncurred;
    }

    // get defence public function

    // THIS FUNCTION IS USED TO SET CANNON ANGLE BEFORE FIRING THE CONNONS
    void setCannonAngle(int cannonColumnIndex, float cannonAngle) {

    }

    // THIS FUNCTION IS USED TO FIRE THE CAONNON AFTER SETTING THE ANGLE
    void fireCannon(int cannonColumnIndex) {

    }

    // THIS FUNTION IS USED TO ROTATE THE SHIPT
    void rotateHull(float rotationAngle) {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}






// SO THIS WAS CLASS BASED PROGRAMMING
// WHERE YOU CREATE REAL LIFE BASED OBJECTS IN code


// Now i will show WHAT FUNCTIONAL PROGRAMMING IS 

// NO REAL life object is imitated


// so lets say i want to create a simple calculator     
// so here 





