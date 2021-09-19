using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
    private Selector topNode = null;
    ShipAIParameters shipParameters;
    public ShipAIActionControls shipControls;

    public float threshold;
    public float shootingRange;
    public float collisionRange;
    public float maneuverableAngle;
    public Hull selfHull;
    public Hull enemyHull;

    void Start()
    {
        shipParameters = new ShipAIParameters(
                threshold,
                shootingRange,
                collisionRange,
                maneuverableAngle,
                selfHull,
                enemyHull
            );

        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        //action Nodes
        IncreaseSailNode increaseSailNode = new IncreaseSailNode();
        DecreaseSailNode decreaseSailNode = new DecreaseSailNode();

        SetSailsToLevelNode setToLevel0Node = new SetSailsToLevelNode(0);
        SetSailsToLevelNode setToLevel1Node = new SetSailsToLevelNode(1);

        IncreaseAngleNode increaseAngleNode = new IncreaseAngleNode();
        DecreaseAngleNode decreaseAngleNode = new DecreaseAngleNode();

        TurnLeftNode turnLeftNode = new TurnLeftNode();
        TurnRightNode turnRightNode = new TurnRightNode();

        FaceTowardsEnemyNode faceTowardsEnemyNode = new FaceTowardsEnemyNode();

        FireCannonNode fireCannonNode = new FireCannonNode();

        //condition Nodes
        float collisionSecondsCoolDown = 5f;
        CollidedWithinNode collidedWithinNode = new CollidedWithinNode(collisionSecondsCoolDown);

        CollisionRangeCheckerNode collisionRangeCheckerNode = new CollisionRangeCheckerNode();
        ShootingRangeCheckerNode shootingRangeCheckerNode = new ShootingRangeCheckerNode();

        EnemyBackCheckerNode enemyBackCheckerNode = new EnemyBackCheckerNode();
        EnemyForwardCheckerNode enemyForwardCheckerNode = new EnemyForwardCheckerNode();
        EnemyLeftCheckerNode enemyLeftCheckerNode = new EnemyLeftCheckerNode();
        EnemyRightCheckerNode enemyRightCheckerNode = new EnemyRightCheckerNode();

        float angleToCheck = 90f;
        EnemyAngleLessThanValueCheckerNode enemyAngleLessThanValueCheckerNode = new EnemyAngleLessThanValueCheckerNode(angleToCheck);

        EnemyCanShootCheckerNode enemyCanShootCheckerNode = new EnemyCanShootCheckerNode();
        CannonShootDistanceLessNode cannonShootDistanceLessNode = new CannonShootDistanceLessNode();

        ManeuverableAngleCheckerNode maneuverableAngleCheckerNode = new ManeuverableAngleCheckerNode();

        HealthCheckerNode healthCheckerNode = new HealthCheckerNode();

        DesiredAngleCheckerNode desiredAngleCheckerNode = new DesiredAngleCheckerNode();
        DesiredCannoRreadyCheckerNode desiredCannoRreadyCheckerNode = new DesiredCannoRreadyCheckerNode();

        //Collection Nodes
        Sequence FireCannon = new Sequence(new List<Node>() { desiredCannoRreadyCheckerNode, fireCannonNode });
        Sequence HitByRam = new Sequence(new List<Node>() { new Inverter(collidedWithinNode), faceTowardsEnemyNode, increaseSailNode });

        Sequence angleIncreaserSequence = new Sequence(new List<Node>() { cannonShootDistanceLessNode, increaseAngleNode });
        Sequence angleDecreaserSequence = new Sequence(new List<Node>() { new Inverter(cannonShootDistanceLessNode), decreaseAngleNode });

        Selector AlignCannonAngle = new Selector(new List<Node>() { desiredAngleCheckerNode, angleIncreaserSequence, angleDecreaserSequence });

        Sequence turnRightIfRightSequence = new Sequence(new List<Node>() { enemyRightCheckerNode, turnRightNode });
        Sequence turnLefttIfLeftSequence = new Sequence(new List<Node>() { enemyLeftCheckerNode, turnLeftNode });

        Selector TurnTowardsEnemy = new Selector(new List<Node>() { turnRightIfRightSequence, turnLefttIfLeftSequence });

        Sequence enemyInManeuverableAngleSequence = new Sequence(new List<Node>() { maneuverableAngleCheckerNode, setToLevel1Node });
        Sequence enemyBackIncreaseSequence = new Sequence(new List<Node>() { enemyBackCheckerNode, increaseSailNode });
        Sequence enemyBack0Sequence = new Sequence(new List<Node>() { enemyBackCheckerNode, setToLevel0Node });

        Selector MoveAway = new Selector(new List<Node>() { enemyBackIncreaseSequence, enemyInManeuverableAngleSequence, decreaseSailNode });

        Selector SailTowardaEnemy = new Selector(new List<Node>() { enemyBack0Sequence, enemyInManeuverableAngleSequence, increaseSailNode });

        Sequence rightAngleTurnLeftSequence = new Sequence(new List<Node>() { enemyAngleLessThanValueCheckerNode, turnLeftNode });
        Sequence rightAngleTurnRightSequence = new Sequence(new List<Node>() { new Inverter(enemyAngleLessThanValueCheckerNode), turnRightNode });

        Sequence leftAngleTurnLeftSequence = new Sequence(new List<Node>() { new Inverter(enemyAngleLessThanValueCheckerNode), turnLeftNode });
        Sequence leftAngleTurnRightSequence = new Sequence(new List<Node>() { enemyAngleLessThanValueCheckerNode, turnRightNode });

        Selector enemyRightSelector = new Selector(new List<Node>() { rightAngleTurnLeftSequence, rightAngleTurnRightSequence });
        Selector enemyLeftSelector = new Selector(new List<Node>() { leftAngleTurnLeftSequence, leftAngleTurnRightSequence });

        Sequence enemyRightSequence = new Sequence(new List<Node>() { enemyRightCheckerNode, enemyRightSelector });
        Sequence enemyLeftSequence = new Sequence(new List<Node>() { enemyLeftCheckerNode, enemyLeftSelector });

        Selector enemyTurnSelector = new Selector(new List<Node>() { enemyRightSequence, enemyLeftSequence });

        Sequence enemyShootMoveSequence = new Sequence(new List<Node>() { enemyCanShootCheckerNode, increaseSailNode });

        Selector enemyMoveSelector = new Selector(new List<Node>() { enemyShootMoveSequence, decreaseSailNode });

        Sequence MoveStrategically = new Sequence(new List<Node>() { enemyTurnSelector, enemyMoveSelector });

        //Main Tree Nodes
        Sequence shootingSequence = new Sequence(new List<Node>() { shootingRangeCheckerNode, AlignCannonAngle, desiredCannoRreadyCheckerNode, FireCannon });

        Sequence towardsEnemySequence = new Sequence(new List<Node>() { TurnTowardsEnemy, SailTowardaEnemy });
        Sequence sailTowardsSequence = new Sequence(new List<Node>() { new Inverter(collisionRangeCheckerNode), towardsEnemySequence });

        Selector aggressiveMoveSelector = new Selector(new List<Node>() { sailTowardsSequence, HitByRam });
        Sequence aggressiveActionSequence = new Sequence(new List<Node>() { shootingSequence, aggressiveMoveSelector });

        Sequence moveAwaySequence = new Sequence(new List<Node>() { collisionRangeCheckerNode, MoveAway });
        Sequence moveStrategicallySequence = new Sequence(new List<Node>() { shootingRangeCheckerNode, MoveStrategically });

        Selector defensiveMoveSelector = new Selector(new List<Node>() { moveAwaySequence, moveStrategicallySequence, towardsEnemySequence });

        Sequence defensiveSequence = new Sequence(new List<Node>() { defensiveMoveSelector, shootingSequence });

        Sequence aggressiveSequence = new Sequence(new List<Node>() { healthCheckerNode, aggressiveActionSequence });

        topNode = new Selector(new List<Node>() { aggressiveSequence, defensiveSequence });
    }

    void FixedUpdate()
    {
        if(topNode != null)
            topNode.Evaluate(shipParameters, shipControls);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collisionRange);
    }
}
