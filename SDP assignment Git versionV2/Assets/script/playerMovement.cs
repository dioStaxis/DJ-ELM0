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
    float verticalmove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        if(joystick.Horizontal >= 0.2f || joystick.Horizontal <=-0.2f)
        {
            horizontalmove = joystick.Horizontal * runspeed;
        }else
        {
            horizontalmove = 0;
        }
        
        animator.SetFloat("speed", Math.Abs(horizontalmove));
        verticalmove = joystick.Vertical;
        if (verticalmove > .5f)
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
        if (verticalmove < -.5f)
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
