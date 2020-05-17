using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private void Start()
    {
        playerCombat.current_weapon = playerCombat.weaponName.sowrd;
        StartCoroutine(SwordTimeout());
    }

    IEnumerator SwordTimeout()
    {
        yield return new WaitForSeconds(10);
        playerCombat.current_weapon = playerCombat.weaponName.hand;
        gameObject.SetActive(false);
    }
}
