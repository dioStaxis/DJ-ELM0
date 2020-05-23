using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    float current_stamina;
    public Animator animator;

    public staminaBar stamina;

    // Start is called before the first frame update
    void Start()
    {
        current_stamina = 0;
        stamina.setMaxStamina(100);
    }

    public void setDeactive()
    {
        gameObject.SetActive(false);
    }
}
