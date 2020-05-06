using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;
    public int maxHealth = 100;
    int currentHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("heart");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.name == "Player")
        {
            Debug.Log("duck you");
            animator.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<playerCombat>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType= RigidbodyType2D.Static;
        }
        if(gameObject.name == "player2")
        {
            Debug.Log("duck you too");
            animator.SetBool("isDead",true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            GetComponent<Player2Movement>().enabled = false;
            GetComponent<p2combat>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        SceneManager.LoadScene("ingame");
    }
}
