using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	[Header("Buttons")]
	public GameObject playButton;
	public GameObject storeButton;
	public GameObject settingsButton;
	public GameObject spButton;
	public GameObject mpButton;
	public GameObject store;
	public GameObject zombieButton;
	public GameObject diamondDisplay;

	[Header("Audio")]
	public AudioSource clickSE;

	public void Play()
	{
		playButton.SetActive(false);
		storeButton.SetActive(false);
		settingsButton.SetActive(false);
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
		playButton.SetActive(false);
		storeButton.SetActive(false);
		settingsButton.SetActive(false);
		store.SetActive(true);
		clickSE.Play();
		diamondDisplay.SetActive(true);
		zombieButton.SetActive(true);
	}
}
