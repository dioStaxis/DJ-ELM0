using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIdentity : MonoBehaviour
{
    private identity_number playernumber;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = "p" + playernumber.addNewPlayer();
    }
}
