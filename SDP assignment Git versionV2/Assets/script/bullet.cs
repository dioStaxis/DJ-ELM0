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

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(DistroyLeftOverBullet());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "froundground")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
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
