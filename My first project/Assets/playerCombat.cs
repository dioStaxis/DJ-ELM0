using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    // Update is called once per frame
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    void Update()
    {
        /*keyboard input
         * if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("p1Attack"))
            {
                animator.SetTrigger("attack");
            nextAttackTime = Time.time + 1f / attackRate; 
            } 
        }*/
    }

    public void mobileAttack()
    {
        if (Time.time >= nextAttackTime)
        {
                animator.SetTrigger("attack");
                nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<playerHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
