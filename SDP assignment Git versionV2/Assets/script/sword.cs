using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{   
    public void equired()
    {
        playerCombat.current_weapon = playerCombat.weaponName.sowrd;
        StartCoroutine(SwordTimeout());
    }

    IEnumerator SwordTimeout()
    {
        yield return new WaitForSeconds(5);
        playerCombat.current_weapon = playerCombat.weaponName.hand;
        gameObject.SetActive(false);
        
    }
}
