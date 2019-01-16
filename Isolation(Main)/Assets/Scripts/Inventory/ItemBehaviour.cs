using Segritude.Interaction;

namespace Segritude.Inventory
{
	public class ItemBehaviour : InteractableBehaviour
	{
		public Item Item;

		public override void OnInteract(InteractionType type)
		{
			Player.Player.Instance.Inventory.AddItem(Item, 1);
		}

		public override bool ValidateInteraction(InteractionType type)
		{
			return type == InteractionType.Main;
		}
	}
}