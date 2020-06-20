using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_combat : MonoBehaviour
{
    //public Animator animator;

    public LayerMask enemyLayer;

    public Transform target;

    public Transform firePoint;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public float fireRate = 2f;
    int attackDamage = 5;
    float nextAttackTime = 0f;
    float nextFireTime = 0f;

    float current_stamina = 0f;
    float MaxStamina = 100;

    public staminaBar stamina;

    Rigidbody2D rb;

    public float detectTargetRange = 3;

    public enum weaponName
    {
        hand, sowrd, ax
    }
    public static weaponName current_weapon = weaponName.hand;


    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        cruuentWeaponStat();

        if (Vector2.Distance(target.position, rb.position) <= detectTargetRange)
        {
            if (Time.time >= nextAttackTime)
            {
                Debug.Log("attacking");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

            if (hitInfo.collider.gameObject.layer.Equals(LayerMask.GetMask("player"))) ;
            {
                if (Time.time >= nextFireTime)
                {
                    if (current_stamina >= 99)
                    {
                        ShootSpecial();
                        current_stamina -= current_stamina;
                        nextFireTime = Time.time + 1f / attackRate;
                    }
                    else
                    {
                        Shoot();
                        nextFireTime = Time.time + 1f / attackRate;
                        Debug.Log("detect enemy!!!");
                    }
                }

            }

        }

        if (current_stamina < MaxStamina)
        {
            current_stamina += (float)(1 * Time.fixedDeltaTime);
        }
        stamina.setStamina(current_stamina);
    }


    void cruuentWeaponStat()
    {
        switch (current_weapon)
        {
            case weaponName.sowrd:
                attackRange = 1f;
                attackRate = 4f;
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
        //animator.SetTrigger("throw");
        weaponShootingAnimation();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void ShootSpecial()
    {
        //animator.SetTrigger("throw");
        weaponShootingAnimation();
        Instantiate(specialBulletPrefab, firePoint.position, firePoint.rotation);
    }


    void Attack()
    {
        //animator.SetTrigger("Attack");
        weaponAttackAnimation();

        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        {
            foreach (Collider2D enemy in hitenemy)
            {

                if (!enemy.name.Equals(this.gameObject.name))
                {
                    Debug.Log(enemy.name);
                    enemy.GetComponent<Health>().takeDamage(attackDamage);
                }
            }
        }
    }

    void weaponAttackAnimation()
    {
        switch (current_weapon)
        {
            case weaponName.sowrd:
                //animator.SetTrigger("sword");
                break;
            case weaponName.ax:
                //animator.SetTrigger("ax");
                break;
            case weaponName.hand:
                break;
            default:
                break;
        }
    }

    void weaponShootingAnimation()
    {
        switch (current_weapon)
        {
            case weaponName.hand:
                break;
            default:
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

