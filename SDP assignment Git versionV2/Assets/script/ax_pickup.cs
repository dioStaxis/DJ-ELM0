using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ax_pickup : NetworkBehaviour
{
    public LayerMask playyerLayer;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (this.gameObject.GetComponent<Collider2D>().IsTouchingLayers(playyerLayer))
        {
            if (hitInfo.GetComponent<weapon>() != null)
            {
                hitInfo.GetComponent<weapon>().equipeAx();
                Destroy(gameObject);
            }

        }

    }
}
