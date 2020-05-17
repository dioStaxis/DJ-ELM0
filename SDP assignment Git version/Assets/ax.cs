using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ax : MonoBehaviour
{
    private void Start()
    {
        playerCombat.current_weapon = playerCombat.weaponName.ax;
        StartCoroutine(AxTimeout());
    }

    IEnumerator AxTimeout()
    {
        yield return new WaitForSeconds(10);
        playerCombat.current_weapon = playerCombat.weaponName.hand;
        gameObject.SetActive(false);
    }
}
