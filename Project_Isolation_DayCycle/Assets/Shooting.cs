using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float damage;
    public float range;

    public Camera cam;

    public float maxBackRecoil;
    public float maxUpRecoil;

    Vector3 desPosition;

    public float recoilSpeed;

    public Transform weapon;

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            Recoil();
        }
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

        }
    }

    void Recoil()
    {
        
    }
}
