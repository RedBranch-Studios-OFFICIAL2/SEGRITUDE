using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaController : MonoBehaviour {

    public float speed;
    public float JumpForce;
    public float Gravity;
    public Vector3 MoveDir = Vector3.zero;

    public GameObject Player;
    Animator anim;
    public GameObject Gun;

    public float ForwardDir;
    public float SideDir;

    public bool Crouch = false;
    public bool Jump = false;

    // Use this for initialization
    void Start ()
    {
        anim = Player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            // Movement Direction
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            ForwardDir = Input.GetAxis("Vertical");
            SideDir = Input.GetAxis("Horizontal");

            anim.SetFloat("MoveY",ForwardDir);
            anim.SetFloat("MoveX", SideDir);

            // Crouch
            if (Input.GetKeyDown(KeyCode.C))
            {
                Crouch = !Crouch;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpFunct();
            }

            MoveDir = Vector3.ClampMagnitude(MoveDir, 1);
            MoveDir = transform.TransformDirection(MoveDir);
            MoveDir *= speed;
        }
        // Gravity
        MoveDir.y -= Gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);

        anim.SetBool("Crouch",Crouch);
    }

    public void JumpFunct()
    {
        StartCoroutine(Jumping());
    }

    IEnumerator Jumping()
    {
        Jump = true;
        anim.SetBool("Jump", Jump);
        yield return new WaitForSeconds(.2f);
        MoveDir.y = JumpForce;
        yield return new WaitForSeconds(.8f);
        Jump = false;
        anim.SetBool("Jump", Jump);
    }
    
}
