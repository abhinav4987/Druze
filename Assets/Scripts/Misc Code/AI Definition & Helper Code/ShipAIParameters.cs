using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAIParameters
{
    public struct Parameters
    {
        public float threshold;
        public float shootingRange;
        public float collisionRange;
        public float manuevrableAngle;
        public Transform enemyTransform;
    }

    public Parameters parameters;

    public ShipAIParameters(float threshold, float shootingRange, float collisionRange, float manuevrableAngle, Transform enemyTransform)
    {
        parameters.threshold = threshold;
        parameters.shootingRange = shootingRange;
        parameters.collisionRange = collisionRange;
        parameters.manuevrableAngle = manuevrableAngle;
        parameters.enemyTransform = enemyTransform;
    }
}
