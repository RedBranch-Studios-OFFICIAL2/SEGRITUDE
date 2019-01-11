using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Segritude.Interaction
{
	/// <summary>
	/// Base class for all interactable objects
	/// </summary>
	public abstract class InteractableBehaviour : MonoBehaviour
	{
		#region Abstract Methods
		/// <summary>
		/// Called when the player succesfully interacts with the object
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		public abstract void OnInteract(InteractionType type);

		/// <summary>
		/// Called when player is trying to interact with the object
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		/// <returns>Is the interaction valid</returns>
		public abstract bool ValidateInteraction(InteractionType type);

		#endregion

		#region Public Methods

		/// <summary>
		/// Try to interact with the object
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		public bool TryInteract(InteractionType type)
		{
			if (!ValidateInteraction(type))
				return false;
			OnInteract(type);
			return true;
		}

		#endregion

		#region Initialization

		/// <summary>
		/// Called at the start of the scene
		/// </summary>
		private void Start()
		{
			gameObject.layer = LayerManager.InteractableLayer;
		}

		#endregion

	}
}
