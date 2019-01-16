using System;
using System.Collections.Generic;
using UnityEngine;

namespace Segritude.Interaction
{
	/// <summary>
	/// Handles all interactions made by player
	/// </summary>
	[RequireComponent(typeof(Camera))]
	public class PlayerInteractor : GlobalBehaviour<PlayerInteractor>
	{
		#region Public Propreties

		/// <summary>
		/// Can player interact right now
		/// </summary>
		public bool CanInteract { get; set; }

		/// <summary>
		/// Is the player currently interacting
		/// </summary>
		public bool IsInteracting { get; private set; }

		/// <summary>
		/// List of interaction hijacks
		/// </summary>
		public List<IInteractable> Hijacks { get; private set; } = new List<IInteractable>();

		#endregion Public Propreties

		#region Serialized Fields

		/// <summary>
		/// Maximal distance to object to perform interaction
		/// </summary>
		[SerializeField] private float _InteractionDistance;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// Interactable that player interact with. Null if not interacting
		/// </summary>
		private IInteractable currentlyInteracting;

		/// <summary>
		/// Interaction type that player is currently performing
		/// </summary>
		private InteractionType currentInteraction;

		#endregion Private Fields

		#region Private Methods

		/// <summary>
		/// Raycasts for interactable behaviour
		/// </summary>
		/// <returns></returns>
		private InteractableBehaviour Raycast()
		{
			RaycastHit hit;
			if (!Physics.Raycast(transform.position, transform.forward, out hit, _InteractionDistance))
				return null;
			return hit.collider.GetComponent<InteractableBehaviour>();
		}

		/// <summary>
		/// Returns if specifined interaction was just attempted
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		/// <returns>Did the interaction just attempted</returns>
		private static bool GetInteractionStart(InteractionType type)
		{
			switch (type)
			{
				case InteractionType.Left:
					return InputManager.InteractLeftDown;

				case InteractionType.Right:
					return InputManager.InteractRightDown;

				case InteractionType.Main:
					return InputManager.InteractMainDown;

				default:
					break;
			}
			return false;
		}

		/// <summary>
		/// Returns if specifined interaction was just finished
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		/// <returns>Did the interaction just finished</returns>
		private static bool GetInteractionEnd(InteractionType type)
		{
			switch (type)
			{
				case InteractionType.Left:
					return InputManager.InteractLeftRelease;

				case InteractionType.Right:
					return InputManager.InteractRightRelease;

				case InteractionType.Main:
					return InputManager.InteractMainRelease;

				default:
					break;
			}
			return false;
		}

		#endregion Private Methods

		#region Unity Callbacks

		private void Update()
		{
			if (!IsInteracting)
			{
				IInteractable interactable = null;
				foreach (InteractionType type in Enum.GetValues(typeof(InteractionType)))
				{
					if (GetInteractionStart(type))
					{
						foreach (var hijack in Hijacks)
							if (hijack.ValidateInteraction(type))
							{
								interactable = hijack;
								break;
							}

						if (interactable == null)
						{
							interactable = Raycast();
							if (!interactable?.ValidateInteraction(type) ?? true)
								interactable = null;
						}
						if (interactable?.ValidateInteraction(type) ?? false)
						{
							currentInteraction = type;
							currentlyInteracting = interactable;
							IsInteracting = true;
						}
					}
				}
			}
			else if ((currentlyInteracting is InteractableBehaviour && Raycast() != currentlyInteracting) || GetInteractionEnd(currentInteraction))
			{
				currentlyInteracting.EndInteraction(currentInteraction);
				currentlyInteracting = null;
				IsInteracting = false;
			}
		}

		#endregion Unity Callbacks
	}
}