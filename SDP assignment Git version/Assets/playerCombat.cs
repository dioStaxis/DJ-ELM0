using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public static int current_weapon = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("attack"))
            {
                switch (current_weapon)
                {
                    case 1: attackRange = 1f;
                        break;
                    default: attackRange = 0.5f;
                        break;
                }
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitenemy)
        {

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return; 
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
