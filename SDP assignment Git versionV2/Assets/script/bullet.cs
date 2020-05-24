using Mirror.Examples.Basic;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(DistroyLeftOverBullet());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (this.GetComponent<Collider2D>().IsTouchingLayers(playerLayer))
        {
            if (hitInfo.GetComponent<Health>() != null)
            {
                hitInfo.GetComponent<Health>().takeDamage(1);
                Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }else if(hitInfo.name == "froundground"|| hitInfo.name == "froundgroundUnspounitem")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            return;
        }
        
        
        
    }

    IEnumerator DistroyLeftOverBullet()
    {
        yield return new WaitForSeconds(10);
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
