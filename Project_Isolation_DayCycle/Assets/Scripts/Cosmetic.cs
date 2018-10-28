using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cosmetic : MonoBehaviour {

	private bool bought;
	public float price;
	public EmeraldCurrency emeraldCurrency;
	public Text priceText;

	// Use this for initialization
	void Start () {
		bought = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!bought)
		{
			priceText.text = price + " emeralds";
		}
		else if (bought)
		{
			priceText.text = "Owned";
		}
	}
	public void Buy()
	{
		if (emeraldCurrency.emeralds < price)
			return;
		else if (emeraldCurrency.emeralds >= price && !bought)
		{
			Debug.Log("You bought " + this);
			emeraldCurrency.emeralds -= price;
			bought = true;
		}
	}
}
