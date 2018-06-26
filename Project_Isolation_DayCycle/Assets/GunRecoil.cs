using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour {

    public GameObject Gun;
    public float Speed = 0.01f;


    // Recoils the gun
    void Update ()
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
            for(int i = 0; i < 10; i++)
            {
                Debug.Log("Shot!");
                Gun.transform.localRotation = Quaternion.Lerp(Gun.transform.localRotation, Gun.transform.localRotation = Quaternion.Euler(-90, 90, -45), Speed * Time.deltaTime);
                //Gun.transform.localPosition = Gun.transform.localPosition + new Vector3(0.5f, 0.5f, 0);
                yield return new WaitForSeconds(0.0000001f);
            }
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            for (int i = 0; i < 30; i++)
            {
                Debug.Log("Shot!");
                Gun.transform.localRotation = Quaternion.Lerp(Gun.transform.localRotation, Gun.transform.localRotation = Quaternion.Euler(0, 0, 0), Speed * Time.deltaTime);
                //Gun.transform.localPosition = Gun.transform.localPosition + new Vector3(0.5f, 0.5f, 0);
                yield return new WaitForSeconds(0.0000001f);
            }
        }

        Debug.Log(Gun);
        yield return new WaitForSeconds(0.05f);
    }
}
