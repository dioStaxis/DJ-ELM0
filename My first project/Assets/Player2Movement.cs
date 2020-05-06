using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("P2Horizontal") * runSpeed;
		animator.SetFloat("P2Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("P2Jump"))
		{
			jump = true;
			animator.SetBool("P2isJumping", true);
		}

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	public void OnLanding()
	{
		animator.SetBool("P2isJumping", false);
	}

	private void Start()
	{
		transform.Rotate(0, 180, 0);
	}
}
