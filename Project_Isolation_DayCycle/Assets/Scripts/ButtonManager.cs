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
}
