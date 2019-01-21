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

	#endregion Serialized Fields

	#region Private Fields

	private Vector3 velocity;
	private bool isCrouching;
	private bool isJumping;
	private CharacterController controller;

	#endregion Private Fields

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if (controller.isGrounded)
		{
			if (isJumping)
			{
				isJumping = false;
				animator.SetBool("Jump", false);
			}

			var rawMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			velocity += transform.rotation * rawMove * Time.deltaTime * acceleretionSpeed;

			animator.SetFloat("MoveX", rawMove.x);
			animator.SetFloat("MoveY", rawMove.z);

			if (Input.GetKeyDown(KeyCode.C))
			{
				isCrouching ^= true;
				animator.SetBool("Crouch", isCrouching);
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				velocity.y = heightJump;
				animator.SetBool("Jump", true);
				isJumping = true;
			}
		}

		velocity.y += Physics.gravity.y * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime * speed);
		velocity *= sliperyness;
	}
}