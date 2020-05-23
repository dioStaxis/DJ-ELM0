using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collisionData)
    {
        Collider2D objectWeCollidedWith = collisionData.collider;
        Health player = objectWeCollidedWith.GetComponent<Health>();
        if(player != null)
        {
            player.takeDamage(5);
        }
    }
}
