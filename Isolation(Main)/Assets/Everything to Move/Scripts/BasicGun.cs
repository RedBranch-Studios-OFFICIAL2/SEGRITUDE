using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    public float range = 50f;
    public float damage = 10f;

    public float clip = 30f;
    public float max = 30f;

    public bool Debounce = false;

    public Camera fpsCam;
    public GameObject Barrel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && clip > 0 && Debounce == false)
        {
            Debounce = true;

           clip -= 1;
            Debug.Log("Clip: " + clip);
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && clip < max)
        {
            if (clip < max)
            {
                Reload();
            }
        }

    }

    void Reload()
    {
        clip = max;
        Debug.Log("Clip: " + clip);
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 forward = fpsCam.transform.TransformDirection(Vector3.forward) * range;
        Debug.DrawRay(Barrel.transform.position, forward, Color.red);



        if (Physics.Raycast(Barrel.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Damage target = hit.transform.GetComponent<Damage>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        StartCoroutine(FireRate());
    }


    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(.1f);
        Debounce = false;
    }
  
}
