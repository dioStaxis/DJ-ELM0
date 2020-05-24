using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public player_controller controller;
    public Animator animator;

    public Joystick joystick;
    float horizontalmove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        if(joystick.Horizontal >= .2f)
        {
            horizontalmove = runspeed;
        }else if (joystick.Horizontal <= -.2f)
        {
            horizontalmove = -runspeed;
        }
        else
        {
            horizontalmove = 0;
        }

        float verticalMove = joystick.Vertical;

        animator.SetFloat("speed", Math.Abs(horizontalmove));

        if (verticalMove>=.5f)
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
        if (verticalMove <= .5f)
        {
            crouch = true;
        }else
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
