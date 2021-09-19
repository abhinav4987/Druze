using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerInformation : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public Vector3 getPlayerPosition()
    {
        return player.transform.position;
    }

    public float getPlayerAngle()
    {
        Debug.DrawRay(transform.position, transform.up);
        Debug.DrawLine(transform.position, player.transform.position);
        return Vector2.SignedAngle(transform.up,(Vector2)(player.transform.position - transform.position));
    }

    public float getPlayerDistance()
    {
        return Vector2.Distance(transform.position, player.transform.position);
    }
}
