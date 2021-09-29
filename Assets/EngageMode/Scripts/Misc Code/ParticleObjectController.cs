using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleObjectController : MonoBehaviour
{
    float timeLeft;

    private void Awake()
    {
        timeLeft = GetComponent<ParticleSystem>().main.startLifetime.constantMax;
    }

    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            Destroy(gameObject);
    }
}
