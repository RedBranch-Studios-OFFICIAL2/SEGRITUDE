using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmeraldCurrency : MonoBehaviour
{
	public float emeralds;

	[Header("UI")]
	public Text emeraldDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		emeraldDisplay.text = "Emeralds: " + emeralds;
	}
}
