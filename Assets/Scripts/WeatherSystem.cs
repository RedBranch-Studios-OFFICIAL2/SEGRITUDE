using System.Collections;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
	public GameObject CurrentWeather;

	public float Speed = .5f;
	public bool Move = false;

	public float SpawnX = -30f;
	public float SpawnZMax = 30f;
	public float SpawnZMin = -30f;

	public float MaxTime = 10f;
	public float MinTime = 5f;

	// Use this for initialization
	private void Start()
	{
		Spawn();
	}

	// Update is called once per frame
	private void Update()
	{
		if (CurrentWeather.transform.localPosition.x < 30 && Move)
			CurrentWeather.transform.localPosition = CurrentWeather.transform.localPosition + new Vector3(Speed, 0, 0) * Time.deltaTime;
		else if (CurrentWeather.transform.localPosition.x >= 30)
		{
			Move = false;
			Spawn();
		}
	}

	public void Spawn()
	{
		CurrentWeather.transform.localPosition = new Vector3(SpawnX, 0, Random.Range(SpawnZMin, SpawnZMax));
		StartCoroutine(WaitingTime());
	}

	private IEnumerator WaitingTime()
	{
		yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
		Move = true;
	}
}