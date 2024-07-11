using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float damage;
    public void setStats(float damage, float shotSpeed, float lifeTime)
    {
        this.damage = damage;
        GetComponent<Rigidbody2D>().AddForce(transform.up * shotSpeed * 10);

        destroyItself(lifeTime);
    }
    private void destroyItself(float x)
    {
        Destroy(gameObject, x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // do something
        }
        Debug.Log("Hitted: " + collision.gameObject.name);
        Destroy(gameObject);
    }
}
