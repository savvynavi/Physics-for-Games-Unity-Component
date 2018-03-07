﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {
	CharacterController controller = null;
	Animator animator = null;
	Ragdoll ragdoll = null;

	bool isGrounded = true;
	bool jumpInput;
	public float speed = 80.0f;
	public float pushPower = 2.0f;
	public float velocityY = 0;
	public float jmpSpeed = 6.0f;
	public float gravity = 20.0f;
	Vector3 dir = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		ragdoll = GetComponent<Ragdoll> ();
	}
	
	// Update is called once per frame
	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		if(ragdoll && ragdoll.RagdollOn ){
			return;
		}

		jumpInput = Input.GetKeyDown(KeyCode.Space);

		//controller.SimpleMove (transform.up * Time.deltaTime);
		transform.Rotate (transform.up, horizontal * speed * Time.deltaTime);
		animator.SetFloat ("Speed", vertical * speed * Time.deltaTime);
		animator.SetBool("Jumping", !isGrounded);

		//set crouch animation ~REMOVE MAGIC NUMBERS~
		if(Input.GetKey(KeyCode.C)) {
			animator.SetBool("Crouching", true);
			controller.height = controller.height / 2;
			controller.center = new Vector3(0, 0.93f / 2f, 0);
		}else {
			animator.SetBool("Crouching", false);
			controller.height = 1.86f;
			controller.center = new Vector3(0, 1.86f / 2f, 0);
		}

		//debug info here
		print(controller.velocity);
	}

	private void FixedUpdate() {
		//if it can jump, add velocity to y direction
		RaycastHit hit;
		Vector3 castPos = new Vector3(transform.position.x, transform.position.y + controller.radius + controller.skinWidth, transform.position.z);
		//casts a sphere down and if the surface is within range, it grounds the character
		if(Physics.SphereCast(castPos, controller.radius, Vector3.down, out hit, 0.1f)) {
			isGrounded = true;

		}else {
			isGrounded = false;
		}

		//clamp downwards? falling off edge causes model to instantly disappear
		if(jumpInput && isGrounded) {
			dir.y = jmpSpeed;
		}

		dir.y -= gravity * Time.deltaTime;
		controller.Move(dir * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		Rigidbody body = hit.collider.attachedRigidbody;
		if(body == null || body.isKinematic){
			return;
		}
		if(hit.moveDirection.y < -0.3f){
			return;
		}

		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}	
}
