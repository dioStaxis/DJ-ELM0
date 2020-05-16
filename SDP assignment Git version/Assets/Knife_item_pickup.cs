using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_item_pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.IsTouchingLayers(9))
        {
            hitInfo.GetComponent<weapon>().equipeSword();
            Destroy(gameObject);
        }

    }
}
