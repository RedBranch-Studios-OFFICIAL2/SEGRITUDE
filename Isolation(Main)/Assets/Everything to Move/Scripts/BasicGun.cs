using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private GunData gun;
    #endregion

    public bool Debounce = false;

    public Camera fpsCam;
    public GameObject Barrel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && gun.clip > 0 && Debounce == false)
        {
            Debounce = true;

            gun.clip -= 1;
            Debug.Log("Clip: " + gun.clip);
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && gun.clip < gun.max)
        {
            if (gun.clip < gun.max)
            {
                Reload();
            }
        }

    }

    void Reload()
    {
        gun.clip = gun.max;
        Debug.Log("Clip: " + gun.clip);
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 forward = fpsCam.transform.TransformDirection(Vector3.forward) * gun.range;
        Debug.DrawRay(Barrel.transform.position, forward, Color.red);



        if (Physics.Raycast(Barrel.transform.position, fpsCam.transform.forward, out hit, gun.range))
        {
            Debug.Log(hit.transform.name);

            Damage target = hit.transform.GetComponent<Damage>();
            if (target != null)
            {
                target.TakeDamage(gun.damage);
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
