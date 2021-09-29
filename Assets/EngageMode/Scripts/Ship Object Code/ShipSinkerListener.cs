using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSinkerListener : MonoBehaviour
{
    private void Start()
    {
        GetComponentInChildren<Hull>().OnDefeat += ShipSinkerListener_OnDefeat;
    }

    private void ShipSinkerListener_OnDefeat(object sender, System.EventArgs e)
    {
        Debug.Log("Sinking Ship");
        GetComponent<ShipSinker>().SinkShip();
    }
}
