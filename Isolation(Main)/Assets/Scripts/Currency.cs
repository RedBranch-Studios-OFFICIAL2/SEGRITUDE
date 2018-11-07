using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour 
{
	[Header("Currency")]
	public float coins;
	public float diamonds;

	[Header("UI")]
	public Text coinsDisplay;
	public Text diamondsDisplay;

	void Update()
	{
		coinsDisplay.text = "Coins: " + coins;
		diamondsDisplay.text = "Diamonds " + diamonds;
	}
}
