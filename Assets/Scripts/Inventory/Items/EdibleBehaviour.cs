using Segritude.Interaction;
using Segritude.Player;
using UnityEngine;

namespace Segritude.Inventory.Items
{
	public class EdibleBehaviour : InteractableItemBehaviour
	{
		#region Public Properties

		public new Edible Item => base.Item as Edible;

		#endregion Public Properties

		#region InteractableItem Implementation

		protected override bool ImidiateInteraction => false;

		protected override float InteractionTime => Item.EatTime;

		protected override InteractionType InteractionTypes => InteractionType.Right ;

		protected override bool RepeatInteraction => false;

		public override void OnInteract(InteractionType type)
		{
			PlayerBehaviour.Instance.Health += Item.HealthGain;
			PlayerBehaviour.Instance.Hunger += Item.HungerGain;
			PlayerBehaviour.Instance.Thirst += Item.ThirstGain;
			PlayerBehaviour.Instance.Stamina += Item.StaminaGain;

			PlayerBehaviour.Instance.SelectedItem.Quantity--;
			PlayerBehaviour.Instance.UpdateToolbar();
		}

		#endregion InteractableItem Implementation
	}
}