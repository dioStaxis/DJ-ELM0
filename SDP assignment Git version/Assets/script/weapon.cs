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
        Ax.SetActive(false);
        Sword.SetActive(true);
    }
    public void equipeAx()
    {
        Sword.SetActive(false);
        Ax.SetActive(true);
    }
}
