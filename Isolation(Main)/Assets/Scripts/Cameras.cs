using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{

	public GameObject Camera;


	public Vector3 OrigPos = new Vector3(0f, 0.722f, -0.055f);
	public Vector3 ThirdPos = new Vector3(0.884f, 0.873f, -0.694f);
	public Vector3 ZoomIn = new Vector3(0.306f, 0.625f, 0.123f);

	public Vector3 LastPos;

	public bool Switch;

	// Use this for initialization
	void Start()
	{
		Switch = false;
		Camera.transform.localPosition = OrigPos;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && Switch == false)
		{
			Switch = true;
			Camera.transform.localPosition = Vector3.Lerp(OrigPos, ThirdPos, 1f);
			LastPos = ThirdPos;
		}
		else if (Input.GetKeyDown(KeyCode.Tab) && Switch == true)
		{
			Switch = false;
			Camera.transform.localPosition = Vector3.Lerp(ThirdPos, OrigPos, 1f);
			LastPos = OrigPos;
		}

		if (Input.GetMouseButtonDown(1))
		{
			Camera.transform.localPosition = Vector3.Lerp(LastPos, ZoomIn, 1f);
		}
		else if (Input.GetMouseButtonUp(1))
		{
			Camera.transform.localPosition = Vector3.Lerp(ZoomIn, LastPos, 1f);
		}
	}
}
