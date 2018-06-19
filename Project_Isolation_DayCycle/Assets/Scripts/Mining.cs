using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour {

    int stonehealth = 3;
    int rayLenght = 10;
    GameObject stone;
    float hit = 1;
    RaycastHit shoot;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, hit, rayLenght))
        { 
        
            if (shoot.collider.gameObject.tag == "Stone")
            {
                stone = shoot.collider.gameObject;
                //CAN INSERT GAMEPLAY SHIT HERE

                if (Input.GetKeyDown("Fire1") == true)
                {
                    stonehealth -= 1;
                    if(stonehealth <= 0)
                    {
                        Destroy(stone);
                    }
                }
            }
        }
	}
}
