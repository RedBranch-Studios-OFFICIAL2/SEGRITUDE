using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Segritude
{
	/// <summary>
	/// Used for playing sounds
	/// </summary>
	[RequireComponent(typeof(AudioListener))]
	[RequireComponent(typeof(AudioSource))]
	public class AudioPlayer : GlobalBehaviour<AudioPlayer>
	{
		#region Private Fields

		/// <summary>
		/// Reference to local audio listener
		/// </summary>
		private AudioSource _Source;

		#endregion

		#region Initialization

		/// <summary>
		/// Called at the beggining of the scene
		/// </summary>
		private void Start()
		{
			_Source = GetComponent<AudioSource>();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Play sound for the player
		/// </summary>
		/// <param name="clip">Sound to play. See <see cref="AudioClip"/></param>
		public void PlaySound(AudioClip clip)
		{
			_Source.PlayOneShot(clip);
		}

		#endregion
	}
}
