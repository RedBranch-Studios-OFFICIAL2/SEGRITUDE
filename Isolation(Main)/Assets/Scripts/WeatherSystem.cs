using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour {

    public GameObject WeatherHolder;
    public GameObject Clouds;
    public GameObject Rain;

    // Timing and Durations
    public float Duration;
    public float CoolDown;

    public float GameDay;

    public bool WeatherActive;
    public bool Moving;

    void Start()
    {
        WeatherHolder.transform.position = new Vector3(11,26,26);

        WeatherActive = false;
        Moving = false;

        Duration = Random.Range(60f,1200f);
        Debug.Log(Duration);
        CoolDown = Random.Range(60f,600f);
        Debug.Log(CoolDown);
    }

    void Update()
    {
        if(Moving == true)
        {
            WeatherHolder.transform.position = WeatherHolder.transform.position + new Vector3(0, 0, 1) * Time.deltaTime;
        }

        if(WeatherActive == false)
        {
            WeatherActive = true;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Weather Active");
        if(Moving == false)
        {
            Moving = true;
            Clouds.SetActive(true);
            Rain.SetActive(true);
        }

        yield return new WaitForSeconds(Duration);
        Debug.Log("Weather Deactive");
       if(Moving == true)
        {
            Moving = false;
            Clouds.SetActive(false);
            Rain.SetActive(false);
            WeatherHolder.transform.position = new Vector3(11, 26, 26);
        }

        yield return new WaitForSeconds(CoolDown);
        WeatherActive = false;
    }
}
