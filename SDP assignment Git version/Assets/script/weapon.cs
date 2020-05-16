using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public GameObject swordPrefab;
    public GameObject Sword;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animator.SetTrigger("throw");
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void equipeSword()
    {
        Sword.SetActive(true);
    }
}
