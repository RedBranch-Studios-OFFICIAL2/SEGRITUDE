using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{

    public GameObject Gun;
    public float Speed = 3f;


    // Recoils the gun
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Print");
        }
    }

    IEnumerator Print()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shot!");

            for(int i = 0; i < 10; i++)
            {
                Debug.Log("Up");
                Gun.transform.localRotation = Quaternion.Lerp(Gun.transform.localRotation, Quaternion.Euler(-60, 0, 0), 0.5f);
                yield return new WaitForSeconds(Time.deltaTime);
            }

            for(int i = 0; i < 10; i++)
            {
                Debug.Log("Down");
                Gun.transform.localRotation = Quaternion.Lerp(Gun.transform.localRotation, Quaternion.Euler(0, 0, 0), 0.5f);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        Debug.Log(Gun);
        yield return new WaitForSeconds(0.05f);
    }
}
