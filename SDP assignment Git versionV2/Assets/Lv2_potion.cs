using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv2_potion : MonoBehaviour
{
    public LayerMask playyerLayer;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (this.gameObject.GetComponent<Collider2D>().IsTouchingLayers(playyerLayer))
        {
            hitInfo.GetComponent<Health>().heal(70);
            Destroy(gameObject);
        }

    }
}
