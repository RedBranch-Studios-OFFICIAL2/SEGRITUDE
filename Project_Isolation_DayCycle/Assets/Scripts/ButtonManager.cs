using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	[Header("Buttons")]
	public GameObject spButton;
	public GameObject mpButton;
	public GameObject store;
	public GameObject settingsPanel;
	public GameObject zombieButton;
	public GameObject diamondDisplay;
	public GameObject mainMenu;
	public GameObject play_Back;
	public GameObject itemshop_Back;
	public GameObject settings_Back;


	[Header("Tabs")]
	public GameObject addEmeraldsTab;

	[Header("Scripts")]
	public EmeraldCurrency emeraldCurrency;

	public void Play()
	{
	    play_Back.SetActive(true);
		mainMenu.SetActive(false);
		spButton.SetActive(true);
		mpButton.SetActive(true);
	}
	public void Play_Back()
	{
		mainMenu.SetActive(true);
		spButton.SetActive(false);
		mpButton.SetActive(false);
		play_Back.SetActive(false);
	}
	public void Singleplayer()
	{
		SceneManager.LoadScene("main");
	}
	public void Store()
	{
		mainMenu.SetActive(false);
		store.SetActive(true);
		diamondDisplay.SetActive(true);
		zombieButton.SetActive(true);
		itemshop_Back.SetActive(true);
	}
	public void Store_Back()
	{
		addEmeraldsTab.SetActive(false);
		mainMenu.SetActive(true);
		store.SetActive(false);
		diamondDisplay.SetActive(false);
		zombieButton.SetActive(false);
		itemshop_Back.SetActive(false);
	}
	public void Settings()
	{
		settings_Back.SetActive(true);
		mainMenu.SetActive(false);
		settingsPanel.SetActive(true);
		itemshop_Back.SetActive(true);
	}
	public void Settings_Back()
	{
		mainMenu.SetActive(true);
		settingsPanel.SetActive(false);
		itemshop_Back.SetActive(false);
	}
	public void OpenAddEmeraldTab()
	{
		addEmeraldsTab.SetActive(true);
		store.SetActive(false);
	}
	public void BuyEmeralds100()
	{
		emeraldCurrency.emeralds += 100;
	}
	public void BuyEmeralds500()
	{
		emeraldCurrency.emeralds += 500;
	}
	public void BuyEmeralds2000()
	{
		emeraldCurrency.emeralds += 2000;
	}
}
