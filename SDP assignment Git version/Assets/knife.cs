using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
