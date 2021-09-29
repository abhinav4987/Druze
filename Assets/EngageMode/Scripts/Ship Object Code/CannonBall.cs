using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonBall : MonoBehaviour
{
    public ParticleSystem explosionPS;

    [SerializeField]
    private float damage;
    
    public float GetDamage()
    {
        return damage;
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void Update()
    {
        if (transform.position.y < -1.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPS, collision.GetContact(0).point, Quaternion.identity);
        IDamageHandler damageHandler = collision.gameObject.GetComponent<IDamageHandler>();
        if (damageHandler != null)
        {
            damageHandler.Damage(GetDamage());
        }
    }

}
