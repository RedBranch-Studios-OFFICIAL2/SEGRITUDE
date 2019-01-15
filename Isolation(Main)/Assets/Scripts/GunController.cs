using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

	public float Speed;

	public Camera fpsCam;
	public GameObject Camera;

	public GameObject Player;
	Animator anim;

	public GameObject gun;
	public GameObject Revolver;

	public GameObject bullet;

	public GameObject AmmoDisplay;
	public Image Background;

	public int Amount = 6;
	public int Max = 6;

	private Vector3 OrigPos = new Vector3(0f, 0.84f, 0.245f);
	private Vector3 ThirdPos = new Vector3(0.25f, 1f, -0.5f);
	private Vector3 ZoomIn = new Vector3(0.081f, 0.798f, 0.533f);

	public Vector3 LastPos;

	public bool Hit = false;
	public bool Reloading = false;
	public bool Reloaded = false;
	public bool CamSwitch = false;
	public bool Switch;

	void Start()
	{
		AmmoDisplay.GetComponent<Text>().text = (Amount.ToString() + "/" + Max.ToString());
		Switch = false;
		Camera.transform.localPosition = OrigPos;
		anim = Player.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

		// Gun Shots // Reloading
		if (Input.GetButtonDown("Fire1"))
		{
			if (Amount > 0)
			{
				Shoot();
				Amount = Amount - 1;
				Debug.Log(Amount);
				AmmoDisplay.GetComponent<Text>().text = (Amount.ToString() + "/" + Max.ToString());
			}
			else if (Amount == 0 && Switch == false && Reloading == false)
			{
				Reloading = true;
				ReloadAva();
				ReloadProcess();
			}
		}
		else if (Amount < Max && Input.GetKeyDown("r") && Reloading == false)
		{
			Reloading = true;
			ReloadAva();
			ReloadProcess();
		}

		// Cam Perspective
		if (Input.GetKeyDown(KeyCode.Tab) && CamSwitch == false)
		{
			CamSwitch = true;
			Camera.transform.localPosition = Vector3.Lerp(LastPos, ThirdPos, 1f);
			LastPos = ThirdPos;
		}
		else if (Input.GetKeyDown(KeyCode.Tab) && CamSwitch == true)
		{
			CamSwitch = false;
			Camera.transform.localPosition = Vector3.Lerp(LastPos, OrigPos, 1f);
			LastPos = OrigPos;
		}

		// Aiming
		if (Input.GetMouseButtonDown(1) && Switch == false)
		{
			Switch = true;
			Camera.transform.localPosition = Vector3.Lerp(OrigPos, ZoomIn, 1f);
			LastPos = ZoomIn;
		}
		else if (Input.GetMouseButtonUp(1) && Switch == true)
		{
			Switch = false;
			Camera.transform.localPosition = Vector3.Lerp(ZoomIn, OrigPos, 1f);
			LastPos = OrigPos;
		}
	}
	// Shooting Bullet
	void Shoot()
	{
		GameObject BulletClone = Instantiate(bullet, Revolver.transform.position + Camera.transform.forward, Revolver.transform.rotation);
		BulletClone.name = "Bullet";
		BulletClone.GetComponent<Rigidbody>().AddForce(Camera.transform.forward * Speed);

	}
	// Reloading Availiable
	void ReloadAva()
	{
		if (Reloading == true)
		{
			anim.SetBool("Walk", false);
			anim.SetBool("Reload", true);
		}
		else if (Reloading == false)
		{
			anim.SetBool("Reload", false);
			anim.SetBool("Walk", true);
		}
	}
	// Reloading Process
	void ReloadProcess()
	{
		Debug.Log("Reloading...");
		StartCoroutine(Reload());
		Debug.Log("Reload Complete");
	}
	// Reloading Core Mechanic
	public IEnumerator Reload()
	{
		Background.GetComponent<Image>().color = Color.Lerp(Background.GetComponent<Image>().color, new Color32(0, 0, 0, 200), 1);
		yield return new WaitForSeconds(5);
		Amount = 6;
		AmmoDisplay.GetComponent<Text>().text = ($"{Amount}/{Max}");
		Background.GetComponent<Image>().color = Color.Lerp(Background.GetComponent<Image>().color, new Color32(0, 0, 0, 36), 1);
		Reloading = false;
		ReloadAva();
	}

}
