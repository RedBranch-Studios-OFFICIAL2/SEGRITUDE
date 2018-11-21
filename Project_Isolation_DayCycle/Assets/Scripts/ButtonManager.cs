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

	[Header("Audio")]
	public AudioSource clickSE;

	[Header("Tabs")]
	public GameObject addEmeraldsTab;

	[Header("Scripts")]
	public EmeraldCurrency emeraldCurrency;

	public void Play()
	{
		mainMenu.SetActive(false);
		spButton.SetActive(true);
		mpButton.SetActive(true);
		clickSE.Play();
	}
	public void Singleplayer()
	{
		SceneManager.LoadScene("main");
		clickSE.Play();
	}
	public void Store()
	{
		mainMenu.SetActive(false);
		store.SetActive(true);
		clickSE.Play();
		diamondDisplay.SetActive(true);
		zombieButton.SetActive(true);
	}
	public void Settings()
	{
		mainMenu.SetActive(false);
		settingsPanel.SetActive(true);
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
