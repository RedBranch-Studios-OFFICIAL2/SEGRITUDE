using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject swatPrefab;
	public GameObject area;
	public int maxEnemies;

	private int currentEnemies;

	private void Update()
	{
		SpawnEnemies();
	}

	private void SpawnEnemies()
	{
		if (CheckAmountOfEnemies())
		{
			var swat = (GameObject)Instantiate(swatPrefab, this.transform.position, this.transform.rotation);
			swat.GetComponent<AIController>().area = area;
			currentEnemies++;
		}
	}

	private bool CheckAmountOfEnemies()
	{
		if (currentEnemies < maxEnemies)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}