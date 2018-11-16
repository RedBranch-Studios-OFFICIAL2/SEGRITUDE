using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour {

    //Colider
    private Collider col;

    //Rigbody
    private Rigidbody rb;

    //Coin Sound
    public AudioSource coinSound;

    //Speed of ball
    public float speed;

    //Ball jump
    public float jumpForce;   

    bool pressedJump = false;

    //size of player
    Vector3 size;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        //get player size
        size = col.bounds.size;
    }

    void FixedUpdate()
    {

        //Walking
        WalkHandler();

        //Jumping
        JumpHandler();

    }

    void WalkHandler()
    {
        //Moving Horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Moving Vertical
        float moveVertical = Input.GetAxis("Vertical");

        //Movment Vector
        Vector3 movment = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Speed of movment
        rb.AddForce(movment * speed);
    }

    void JumpHandler()
    {
        //Input of the JUmp axis
        float jumpBall = Input.GetAxis("Jump");

        //If the pressed jump or not
        if(jumpBall > 0)
        {
            bool isGrounded = CheckGround();
             
            //making sure we are not jumping
            if (!pressedJump && isGrounded)
            {
                pressedJump = true;

                //Jumping vector
                Vector3 jumpVector = new Vector3(0, jumpBall * jumpForce, 0);

                //apply force
                rb.AddForce(jumpVector, ForceMode.VelocityChange);

            }
        }
        else
        {
            //set flag to false
            pressedJump = false;
        }
    }

    bool CheckGround()
    {
        //location of corners
        Vector3 corner1 = transform.position + new Vector3(size.x / 2, -size.y / 2, size.z / 2);
        Vector3 corner2 = transform.position + new Vector3(-size.x / 2, -size.y / 2, size.z / 2);
        Vector3 corner3 = transform.position + new Vector3(size.x / 2, -size.y / 2, -size.z / 2);
        Vector3 corner4 = transform.position + new Vector3(-size.x / 2, -size.y / 2, -size.z / 2);

        //check if we are grounded
        bool grounded1 = Physics.Raycast(corner1, -Vector3.up, 0.01f);
        bool grounded2 = Physics.Raycast(corner2, -Vector3.up, 0.01f);
        bool grounded3 = Physics.Raycast(corner3, -Vector3.up, 0.01f);
        bool grounded4 = Physics.Raycast(corner4, -Vector3.up, 0.01f);

        return (grounded1 || grounded2 || grounded3 || grounded4);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            print("We got coin");

            //Coin Audio
            coinSound.Play();

           //Destroying coin from game
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            print("U Died");
        }
        else
        {
            if (other.CompareTag("Finish"))
            {
                print("Done");
            }
        }

    }


}
