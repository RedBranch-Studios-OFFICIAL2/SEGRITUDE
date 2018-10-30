using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaController : MonoBehaviour {

    public float speed = 4f;
    public float JumpForce = 6f;
    public float Gravity = 20f;
    public Vector3 MoveDir = Vector3.zero;

    public GameObject Player;
    Animator anim;
    public GameObject Gun;
    
    public bool Jump;
    public bool Walk = false;
    public bool Crouch;
    public bool Prone;
    public bool Run;
    public bool Action = false;

    public float ForwardDir;
    public float SideDir;

    public int Level = 3;

    // Use this for initialization
    void Start ()
    {
        Jump = false;
        Run = false;
        Prone = false;
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
            // Forward and Backwards Directions
            if (ForwardDir > 0 && Walk == false && Run == false && Jump == false)
            {
                Walk = true;
                anim.SetBool("WalkBack", false);
                anim.SetBool("Walk", true);
            }
            else if (ForwardDir < 0 && Walk == false && Run == false && Jump == false)
            {
                Walk = true;
                anim.SetBool("Walk", false);
                anim.SetBool("WalkBack", true);
            }
            else if(ForwardDir == 0)
            {
                Walk = false;
                anim.SetBool("WalkBack", false);
                anim.SetBool("Walk", false);
            }
            // Left and Right Directions
            if (SideDir < 0 && Walk == false && Run == false && Jump == false)
            {
                Walk = true;
                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", true);
            }
            else if (SideDir > 0 && Walk == false && Run == false && Jump == false)
            {
                Walk = true;
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", true);
            }
            else if(SideDir == 0)
            {
               // Walk = false;
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", false);
            }

            MoveDir = Vector3.ClampMagnitude(MoveDir, 1);

            MoveDir = transform.TransformDirection(MoveDir);

            MoveDir *= speed;
            // Sprinting Script
            if (Input.GetKeyDown(KeyCode.LeftShift) && Run == false)
            {
                Run = true;
                Running();
                speed = speed * 1.5f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) && Run == true)
            {
                Run = false;
                Running();
                speed = speed / 1.5f;
            }

            // Crouching Script
            if (Input.GetKeyDown(KeyCode.C) && Jump == false && Crouch == false)
            {
                Crouch = true;
                anim.SetBool("Walk", false);
                anim.SetBool("Crouch", true);
            }
            else if (Input.GetKeyDown(KeyCode.C) && Crouch == true)
            {
                Crouch = false;
                anim.SetBool("Crouch", false);
                anim.SetBool("Walk", false);
            }
            else if (Crouch == true && Walk == true)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Crouch", true);
            }
            else if (Crouch == true && Walk == false)
            {
                anim.SetBool("Walk", false);
            }

            // Prone Script
            if (Input.GetKeyDown(KeyCode.X) && Jump == false && Prone == false)
            {
                Prone = true;
                anim.SetBool("Walk", false);
                anim.SetBool("Prone", true);
            }
            else if (Input.GetKeyDown(KeyCode.X) && Prone == true)
            {
                Prone = false;
                anim.SetBool("Prone", false);
                anim.SetBool("Walk", true);
            }
            else if (Prone == true && Walk == true)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Prone", true);
                speed = 1f;
            }
            else if (Prone == true && Walk == false)
            {
                anim.SetBool("Walk", false);
                speed = 4f;
            }

            // Jump Script
            if (Input.GetButtonDown("Jump") && Jump == false)
            {
                MoveDir.y = JumpForce;
                Jumping();
            }
        }
        // Gravity
        MoveDir.y -= Gravity * Time.deltaTime;

        controller.Move(MoveDir * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Alpha1) && Action == false)
        {
            Action = true;
            gameObject.GetComponent<GunController>().enabled = false;
            Gun.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && Action == true)
        {
            Action = false;
            gameObject.GetComponent<GunController>().enabled = true;
            Gun.SetActive(true);
        }
    }

    public void Running()
    {
        if(Run == true)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
        }
        else if(Run == false)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);
        }
    }

    public void Jumping()
    {
        StartCoroutine(Jumped());
    }
    public IEnumerator Jumped()
    {
        Jump = true;
        anim.SetBool("Walk", false);
        anim.SetBool("Jump", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Jump", false);
        anim.SetBool("Walk", true);
        Jump = false;
    }
    
}
