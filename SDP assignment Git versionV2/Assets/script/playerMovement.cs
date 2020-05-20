using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class playerMovement : NetworkBehaviour
{
    public player_controller controller;
    public Animator animator;

    float horizontalmove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;

    [Client]
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }
        horizontalmove = Input.GetAxisRaw("Horizontal")*runspeed;

        animator.SetFloat("speed", Math.Abs(horizontalmove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
        if (Input.GetButtonDown("crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    public void OnWalking(bool isWalking)
    {
        animator.SetBool("Walking", isWalking);
    }


    private void FixedUpdate()
    {
        controller.Move(horizontalmove*Time.fixedDeltaTime,crouch, jump);
        jump = false;
    }
}
