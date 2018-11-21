using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmeraldCount : MonoBehaviour
{
	public Text emeraldCount;
	public EmeraldCurrency emeraldCurrency;

	void Update()
	{
		emeraldCount.text = "Emeralds: " + emeraldCurrency.emeralds;
	}
}
