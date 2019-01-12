using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		/// Is the player currently interacting
		/// </summary>
		public bool IsInteracting { get; private set; }

		#endregion

		#region Serialized Fields

		/// <summary>
		/// Maximal distance to object to perform interaction
		/// </summary>
		[SerializeField] private float _InteractionDistance;

		#endregion

		#region Private Fields

		/// <summary>
		/// Interactable that player interact with. Null if not interacting
		/// </summary>
		private InteractableBehaviour _CurrentlyInteracting;

		/// <summary>
		/// Interaction type that player is currently performing
		/// </summary>
		private InteractionType _CurrentInteraction;

		#endregion

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
		private bool GetInteractionStart(InteractionType type)
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
		private bool GetInteractionEnd(InteractionType type)
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

		#endregion

		#region Unity Callbacks

		private void Update()
		{
			if (!IsInteracting)
			{
				InteractableBehaviour behaviour = null;
				foreach (InteractionType type in Enum.GetValues(typeof(InteractionType)))
				{
					if (GetInteractionStart(type))
					{
						if (behaviour == null)
						{
							behaviour = Raycast();
							if (behaviour == null)
								return;
						}
						if (behaviour.TryStartInteraction(type))
						{
							_CurrentInteraction = type;
							_CurrentlyInteracting = behaviour;
							IsInteracting = true;
						}
					}
				}
			}
			else
			{
				var behaviour = Raycast();
				if (behaviour != _CurrentlyInteracting || GetInteractionEnd(_CurrentInteraction))
				{
					_CurrentlyInteracting.EndInteraction(_CurrentInteraction);
					_CurrentlyInteracting = null;
					IsInteracting = false;
				}
			}
		}

		#endregion
	}
}
