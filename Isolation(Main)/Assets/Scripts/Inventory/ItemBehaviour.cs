using Segritude.Interaction;
using UnityEngine;

namespace Segritude.Inventory
{
	public class ItemBehaviour : InteractableBehaviour
	{
		[SerializeField] private Item item;

		public override void OnInteract(InteractionType type)
		{
			Player.PlayerBehaviour.Instance.Inventory.AddItem(item, 1);
			Destroy(gameObject);
		}

		public override bool ValidateInteraction(InteractionType type)
		{
			return type == InteractionType.Main;
		}
	}
}