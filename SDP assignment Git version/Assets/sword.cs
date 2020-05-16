using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private void Start()
    {
        playerCombat.current_weapon = 1;
        StartCoroutine(SwordTimeout());
    }

    IEnumerator SwordTimeout()
    {
        yield return new WaitForSeconds(10);
        playerCombat.current_weapon = 0;
        gameObject.SetActive(false);
    }
}
