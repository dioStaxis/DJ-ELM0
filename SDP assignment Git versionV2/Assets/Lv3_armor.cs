using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3_armor : MonoBehaviour
{
    public LayerMask playyerLayer;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (this.gameObject.GetComponent<Collider2D>().IsTouchingLayers(playyerLayer))
        {
            hitInfo.GetComponent<Health>().increaseArmor(50);
            Destroy(gameObject);
        }

    }
}
