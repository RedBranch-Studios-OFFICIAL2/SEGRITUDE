using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

    public float Speed;

    public Camera fpsCam;

    public GameObject gun;
    public GameObject Revolver;
    public GameObject Camera;

    public GameObject bullet;

    public GameObject AmmoDisplay;
    public Image Background;
    public int Amount = 6;
    public int Max = 6;

    public bool Hit = false;
    public bool Reloading = false;

    void Start()
    {
        AmmoDisplay.GetComponent<Text>().text = (Amount.ToString() + "/" + Max.ToString());
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Amount > 0)
            {
                Shoot();
                Amount = Amount - 1;
                Debug.Log(Amount);
                AmmoDisplay.GetComponent<Text>().text = (Amount.ToString() + "/" + Max.ToString());
            }
            else if (Amount == 0)
            {
                ReloadProcess();
            }
        }
        else if (Amount < Max && Input.GetKeyDown("r") && Reloading == false)
        {
            Reloading = true;
            ReloadProcess();
            Reloading = false;
        }
    }

    void Shoot()
    {
        GameObject BulletClone = Instantiate(bullet, Camera.transform.position + Camera.transform.forward * 2f, Revolver.transform.rotation);
        BulletClone.name = "Bullet";
        BulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }
    void ReloadProcess()
    {
        Debug.Log("Reloading...");
        StartCoroutine(Reload());
        Debug.Log("Reload Complete");
    }
    public IEnumerator Reload()
    {
        Background.GetComponent<Image>().color = Color.Lerp(Background.GetComponent<Image>().color, new Color32(0, 0, 0, 200), 1);
        yield return new WaitForSeconds(5);
        Amount = 6;
        AmmoDisplay.GetComponent<Text>().text = (Amount.ToString() + "/" + Max.ToString());
        Background.GetComponent<Image>().color = Color.Lerp(Background.GetComponent<Image>().color, new Color32(0, 0, 0, 36), 1);
    }
}
