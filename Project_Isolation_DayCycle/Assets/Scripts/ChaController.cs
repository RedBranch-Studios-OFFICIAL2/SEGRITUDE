using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaController : MonoBehaviour {

    public float speed = 10f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        float translation = Input.GetAxis("Vertical") * speed;

        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }
}
