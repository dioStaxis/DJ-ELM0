using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Animator animator;
    public GameObject swordPrefab;
    public GameObject sword;
    public GameObject Ax;

    public void equipeSword()
    {
        reloadWeapon();
        sword.SetActive(true);
        sword.GetComponent<sword>().equired();
        
    }
    public void equipeAx()
    {
        reloadWeapon();
        Ax.SetActive(true);
        Ax.GetComponent<ax>().equired();
        
    }

    void reloadWeapon()
    {
        sword.SetActive(false);
        Ax.SetActive(false);
    }
}
