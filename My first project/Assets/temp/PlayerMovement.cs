using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;

	public Joystick joystick;

	float horizontalMove = 0f;
	bool jump = false;

	// Update is called once per frame
	void Update()
	{
		//for capture mobile touch
		if (joystick.Horizontal >= .2f)
		{
			horizontalMove = runSpeed;
		}else if (joystick.Horizontal <= -.2f)
		{
			horizontalMove = -runSpeed;
		}
		else
		{
			horizontalMove = 0f;
		}
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		
		/* keyboard input
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Jump"))
		{
			animator.SetBool("isJumping", true);
			jump = true;
		}*/
	}

	public void mobileJump()
	{
		jump = true;
		animator.SetBool("isJumping", true);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	public void OnLanding()
	{
		animator.SetBool("isJumping", false);
	}

	private void Start()
	{
		transform.Rotate(0, 180, 0);
	}
}