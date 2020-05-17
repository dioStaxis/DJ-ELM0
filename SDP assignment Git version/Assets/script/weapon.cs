using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Animator animator;
    public GameObject swordPrefab;
    public GameObject Sword;
    public GameObject Ax;

    public void equipeSword()
    {
        reloadWeapon();
        Sword.SetActive(true);
        Sword.GetComponent<sword>().equired();
        
    }
    public void equipeAx()
    {
        reloadWeapon();
        Ax.SetActive(true);
        Ax.GetComponent<ax>().equired();
        
    }

    void reloadWeapon()
    {
        Sword.SetActive(false);
        Ax.SetActive(false);
    }
}
