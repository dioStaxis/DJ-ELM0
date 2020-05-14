using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public player_controller controller;
    float horizontalmove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal")*runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalmove*Time.fixedDeltaTime,crouch, jump);
        jump = false;
    }
}
