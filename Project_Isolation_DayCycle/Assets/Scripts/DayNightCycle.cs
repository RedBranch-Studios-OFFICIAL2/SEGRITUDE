using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    public float time;
    public TimeSpan CurrentTime;
    public Transform SunTransform;
    public Light Sun;

    public float Intensity;
    public Color Day = Color.blue;
    public Color Night = Color.black;

    public int Speed;

	// Update is called once per frame
	void Update ()
    {
        ChangeTime();
	}

    public void ChangeTime()
    {
        time += Time.deltaTime * Speed;
        if (time > 86400)
        {
            time = 0;
        }
        CurrentTime = TimeSpan.FromSeconds(time);

        // Rotates the Sun
        SunTransform.rotation = Quaternion.Euler(new Vector3((time -21600) / 86400 * 360, 0, 0 ));
        if (time < 43200)
        
            Intensity = 1 - (43200 - time) / 43200;
        else
            Intensity = 1 - ((43200 - time) / 43200 * -1);

        RenderSettings.ambientSkyColor = Color.Lerp(Day, Night, Intensity * Intensity);

        Sun.intensity = Intensity;
    }
}
