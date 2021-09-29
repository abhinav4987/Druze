using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipSinker : MonoBehaviour
{

    public float endWaitTime = 5.0f;

    public ParticleSystem endExplosion;
    IEnumerator MapModeSwitchCoroutine()
    {
        yield return new WaitForSeconds(endWaitTime);
        SceneManager.LoadScene("MapModeScene");
    }

    public void SinkShip()
    {
        Instantiate(endExplosion, GetComponentInChildren<Hull>().GetShipTransform().position, Quaternion.identity, GetComponentInChildren<Hull>().gameObject.transform);
        StartCoroutine(MapModeSwitchCoroutine());
    }
}
