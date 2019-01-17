using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerEngine : MonoBehaviour
{


	#region Serialized Fields

	[SerializeField] private Animator animator; 
	[SerializeField] private float heightJump;
	[SerializeField] private float acceleretionSpeed = 1;
	[SerializeField] private float speed = 1;
	[SerializeField] private float sliperyness = 0.9f;

	#endregion

	#region Private Fields

	private Vector3 velocity;
	private bool isCrouching;
	private CharacterController controller;
	#endregion

	#region Unity Callbackss

	#endregion

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		if (controller.isGrounded)
		{
			velocity += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * acceleretionSpeed;

			if (Input.GetKeyDown(KeyCode.C))
				isCrouching ^= true;
			if (Input.GetKeyDown(KeyCode.Space))
				velocity.y = heightJump;
		}
		velocity.y += Physics.gravity.y * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime * speed);
		velocity *= sliperyness;
	}
}
