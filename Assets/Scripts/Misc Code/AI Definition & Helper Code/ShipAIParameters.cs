using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAIParameters
{
    [System.Serializable]
    public struct Parameters
    {
        public float threshold;
        public float shootingRange;
        public float collisionRange;
        public float maneuverableAngle;

        [SerializeField]
        private Hull selfHull;
        [SerializeField]
        private Hull enemyHull;

        public void SetSelfHull(Hull enemyHull)
        {
            this.selfHull = enemyHull;
        }

        public Transform GetSelfTransform()
        {
            return selfHull.GetShipTransform();
        }

        public float GetSelfHealth()
        {
            return selfHull.GetHealthPoint();
        }

        public void SetEnemyHull(Hull enemyHull)
        {
            this.enemyHull = enemyHull;
        }

        public Transform GetEnemyTransform()
        {
            return enemyHull.GetShipTransform();
        }

        public float GetEnemyHealth()
        {
            return enemyHull.GetHealthPoint();
        }

        public Vector3 GetEnemyRelativeFromSelf()
        {
            return selfHull.transform.InverseTransformPoint(enemyHull.transform.position);
        }

        public float GetDistanceBetweenSelfAndEnemy()
        {
            return Vector3.Distance(GetSelfTransform().position, GetEnemyTransform().position);
        }

        public float GetPreviousRamCollisionTime()
        {
            return selfHull.GetPrevCollisionTime();
        }

        public float GetSelfCannonInitialSpeed()
        {
            return selfHull.GetCannonInitialSpeed();
        }

        public float GetSelfCannonAngle()
        {
            return selfHull.GetCannonAngle();
        }

        public bool GetSelfCannonReadyState(int groupIndex)
        {
            return selfHull.GetCannonGroupReady(groupIndex);
        }

        public float GetAngleFromSelfToEnemy()
        {
            Transform selfTransform = GetSelfTransform(), enemyTransform = GetEnemyTransform();
            return Vector3.Angle(selfTransform.right, enemyTransform.position - selfTransform.position);
        }

        public float GetAngleFromEnemyToSelf()
        {
            Transform selfTransform = GetSelfTransform(), enemyTransform = GetEnemyTransform();
            return Vector3.Angle(enemyTransform.right, selfTransform.position - enemyTransform.position);
        }
    }

    public Parameters parameters;

    public ShipAIParameters(float threshold, float shootingRange, float collisionRange, float maneuverableAngle, Hull selfHull, Hull enemyHull)
    {
        parameters.threshold = threshold;
        parameters.shootingRange = shootingRange;
        parameters.collisionRange = collisionRange;
        parameters.maneuverableAngle = maneuverableAngle;
        parameters.SetSelfHull(selfHull);
        parameters.SetEnemyHull(enemyHull);
    }
}

