using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Health : MonoBehaviour
{
    float current_health;
    float MaxHealth = 100;
    public Animator animator;

    public healthBar healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        current_health = MaxHealth;
        healthbar.setMaxHealth((int)MaxHealth);
    }

    public void takeDamage(int Damage_value)
    {
        animator.SetTrigger("hurt");
        current_health  = current_health - Damage_value;
        healthbar.setHealth((int)current_health);
        if (current_health <= 0)
        {
            die();
        }
    }

    public void heal(int heal_value)
    {
        current_health = current_health + heal_value;
    }

    public void die()
    {
        animator.SetBool("death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public void setDeactive()
    {
        gameObject.SetActive(false);
    }
}
