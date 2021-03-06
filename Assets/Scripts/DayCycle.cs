﻿using UnityEngine;

public class DayCycle : MonoBehaviour
{
	public float minutesInDay = 1.0f;

	private float timer;
	private float percentageOfDay;
	private float turnSpeed;

	private void Start()
	{
		timer = 0.0f;
	}

	private void Update()
	{
		checkTime();
		UpdateLights();

		turnSpeed = 360.0f / (minutesInDay * 60.0f) * Time.deltaTime;
		transform.RotateAround(transform.position, transform.right, turnSpeed);

		Debug.Log(percentageOfDay);
	}

	private void UpdateLights()
	{
		var l = GetComponent<Light>();
		if (isNight())
		{
			if (l.intensity > 0.0f)
			{
				l.intensity -= 0.05f;
			}
		}
		else
		{
			if (l.intensity < 1.0f)
			{
				l.intensity += 0.05f;
			}
		}
	}

	private bool isNight()
	{
		bool c = false;
		if (percentageOfDay > 0.5f)
		{
			c = true;
		}
		return c;
	}

	private void checkTime()
	{
		timer += Time.deltaTime;
		percentageOfDay = timer / (minutesInDay * 60.0f);
		if (timer > (minutesInDay * 60.0f))
		{
			timer = 0.0f;
		}
	}
}