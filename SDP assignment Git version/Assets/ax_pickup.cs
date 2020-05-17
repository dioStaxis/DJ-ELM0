using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ax_pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.IsTouchingLayers(9))
        {
            hitInfo.GetComponent<weapon>().equipeAx();
            Destroy(gameObject);
        }

    }
}
