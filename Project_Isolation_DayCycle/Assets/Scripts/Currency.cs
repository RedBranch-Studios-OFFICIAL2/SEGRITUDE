using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour 
{
	[Header("Currency")]
	public float coins;
	[Header("UI")]
	public Text coinsDisplay;

	void Update()
	{
		coinsDisplay.text = "Coins: " + coins;

		if (Input.GetKeyDown(KeyCode.T)) //Adds a coin when T is pressed
		{
			coins += 1;
		}
	}
}
