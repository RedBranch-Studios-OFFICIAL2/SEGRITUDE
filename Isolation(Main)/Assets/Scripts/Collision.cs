using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject Bullet;
    public GameObject BulletHole;

    public float Speed = 0.02f;

    public bool Hit = false;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Checks for collision of bullet
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (Hit == false)
        {
            Hit = true;
            GameObject Hole = Instantiate(BulletHole, Bullet.transform.position, Bullet.transform.rotation);
            Hole.name = "BulletHole";
            Destroy(Bullet);
        }
    }

}
