using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Health : MonoBehaviour
{
    float current_health;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        current_health = 100;    
    }

    public void takeDamage(int Damage_value)
    {
        animator.SetTrigger("hurt");
        current_health  = current_health - Damage_value;
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
