using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject UI;
    float current_health;
    float MaxHealth = 100;
    int armorAmount = 0;
    public Animator animator;

    public healthBar healthbar;
    public armorBar ArmorBar;
    
    // Start is called before the first frame update
    void Start()
    {
        current_health = MaxHealth;
        healthbar.setMaxHealth((int)MaxHealth);
        ArmorBar.setArmor(armorAmount);
    }

    public void takeDamage(int Damage_value)
    {
        animator.SetTrigger("hurt");
        int afterArmorBlock = armorAmount - Damage_value;
        if (afterArmorBlock<0)
        {
            armorAmount = 0;
            current_health  = current_health + afterArmorBlock;
        }
        else
        {
            armorAmount = afterArmorBlock;
        }
        ArmorBar.setArmor(armorAmount);
        healthbar.setHealth((int)current_health);
        if (current_health <= 0)
        {
            die();
        }
    }

    public void heal(int heal_value)
    {
        current_health = current_health + heal_value;
        if(current_health>100)
        {
            current_health = 100;
        }
        healthbar.setHealth((int)current_health);
    }

    public void increaseArmor(int increaseArmorAmount)
    {
        this.armorAmount += increaseArmorAmount;
        if (this.armorAmount>50)
        {
            this.armorAmount = 50;
        }
        ArmorBar.setArmor(this.armorAmount);
    }

    public void die()
    {
        animator.SetBool("death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        if (this.gameObject.name.Equals("P1"))
        {
            GameObject p2Win = UI.transform.GetChild(2).gameObject;
            p2Win.SetActive(true);
        }
        else if(this.gameObject.name.Equals("P2"))
        {
            GameObject p1Win = UI.transform.GetChild(1).gameObject;
            p1Win.SetActive(true);
        }
    }

    public void setDeactive()
    {
        gameObject.SetActive(false);
    }

    public float getHealth()
    {
        return current_health;
    }
}
