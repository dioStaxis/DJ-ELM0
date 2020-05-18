using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name.Equals("p1")|| hitInfo.gameObject.name.Equals("p2") || hitInfo.gameObject.name.Equals("p3"))
        {
           if (hitInfo.GetComponent<weapon>() != null)
            {
                hitInfo.GetComponent<weapon>().equipeSword();
                Destroy(gameObject);
            }
            
        }

    }
}
