using Segritude.Interaction;
using UnityEngine;

namespace Segritude.Inventory.Items
{
	public abstract class InteractableItemBehaviour : ItemBehaviour, IInteractable
	{
		#region Public Properties

		/// <summary>
		/// Is the player currently interaction
		/// </summary>
		public bool IsInteracting { get; protected set; }

		#endregion Public Properties

		#region Abstract Properies

		/// <summary>
		/// Acceptable interaction types
		/// </summary>
		protected abstract InteractionType InteractionTypes { get; }

		/// <summary>
		/// Timespan between interactions
		/// </summary>
		protected abstract float InteractionTime { get; }

		/// <summary>
		/// Is the first interaction imidiate
		/// </summary>
		protected abstract bool ImidiateInteraction { get; }

		/// <summary>
		/// Does the interaction repeat
		/// </summary>
		protected abstract bool RepeatInteraction { get; }

		#endregion Abstract Properies

		#region Private Fields

		/// <summary>
		/// Timer for the interaction
		/// </summary>
		private float interactionTimer;

		/// <summary>
		/// Type of the current interaction
		/// </summary>
		private InteractionType interactionType;

		#endregion Private Fields

		#region Unity Callbacks

		/// <summary>
		/// Called one per frame
		/// </summary>
		public void Update()
		{
			if (interactionTimer > 0)
				interactionTimer -= Time.deltaTime;
			Debug.Log(interactionTimer);
			if (IsInteracting && interactionTimer <= 0)
			{
				OnInteract(interactionType);
				if (RepeatInteraction)
					interactionTimer = InteractionTime;
				else
					IsInteracting = false;
			}
		}

		#endregion Unity Callbacks

		#region IInteractable Implementation

		/// <summary>
		/// Called when the player stops interacting
		/// </summary>
		/// <param name="type">Type of the interaction</param>
		public void EndInteraction(InteractionType type) => IsInteracting = false;

		/// <summary>
		/// Called when the player starts interacting
		/// </summary>
		/// <param name="type">Type of the interaction</param>
		public void StartInteraction(InteractionType type)
		{
			IsInteracting = true;
			interactionType = type;
		}

		/// <summary>
		/// Called when the player tries to interact
		/// </summary>
		/// <param name="type">Type of the interaction</param>
		/// <returns></returns>
		public virtual bool ValidateInteraction(InteractionType type) => InteractionTypes.HasFlag(type);

		#endregion IInteractable Implementation

		#region Abstract Methods

		/// <summary>
		/// Called when the player interacts
		/// </summary>
		/// <param name="type">Type of the interaction</param>
		public abstract void OnInteract(InteractionType type);

		#endregion Abstract Methods

		#region Overrides

		public override void OnDeselectItem()
		{
			PlayerInteractor.Instance.Hijacks.Remove(this);
		}

		public override void OnSelectItem()
		{
			interactionTimer = ImidiateInteraction ? 0 : InteractionTime;
			PlayerInteractor.Instance.Hijacks.Add(this);
		}

		#endregion Overrides
	}
}