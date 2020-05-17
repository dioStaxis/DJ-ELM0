﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;

    public LayerMask enemyLayer;

    public Transform firePoint;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public enum weaponName
    {
        hand, sowrd, ax
    }
    public static weaponName current_weapon = weaponName.hand;
    

    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
        cruuentWeaponStat();

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("attack"))
            {
                
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void cruuentWeaponStat()
    {
        switch (current_weapon)
        {
            case weaponName.sowrd:
                attackRange = 1f;
                attackRate = 1f;
                break;
            case weaponName.ax:
                attackRange = 1.2f;
                attackRate = 1f;
                break;
            case weaponName.hand:
                attackRange = 0.5f;
                attackRate = 2f;
                break;
            default:
                attackRange = 0.5f;
                attackRate = 2f;
                break;
        }
    }

    void Shoot()
    {
        animator.SetTrigger("throw");
        weaponShootingAnimation();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Attack()
    {
        
        animator.SetTrigger("Attack");
        weaponAttackAnimation();

         Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitenemy)
        {

        }
    }

    void weaponAttackAnimation()
    {
        switch (current_weapon)
        {
            case weaponName.sowrd:
                animator.SetTrigger("sword");
                break;
            case weaponName.ax:
                animator.SetTrigger("ax");
                break;
            case weaponName.hand:
                break;
            default:
                break;
        }
    }

    void weaponShootingAnimation()
    {

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return; 
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
