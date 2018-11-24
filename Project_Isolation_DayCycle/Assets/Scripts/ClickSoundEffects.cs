using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundEffects : MonoBehaviour {
	public AudioSource play_clickSE;
	public AudioSource store_clickSE;
	public AudioSource settings_clickSE;

	public void Play()
	{
		play_clickSE.Play();
	}
	public void Store()
	{
		store_clickSE.Play();
	}
	public void Settings()
	{
		settings_clickSE.Play();
	}
}
