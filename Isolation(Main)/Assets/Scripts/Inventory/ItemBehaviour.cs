using Segritude.Interaction;
using UnityEngine;

namespace Segritude.Inventory
{
	/// <summary>
	/// Behaviour for item game objects
	/// </summary>
	public class ItemBehaviour : InteractableBehaviour
	{
		/// <summary>
		/// The item data
		/// </summary>
		[SerializeField] private Item item;

		/// <summary>
		/// Callback called when player picks up the item
		/// </summary>
		/// <param name="type"></param>
		public override void OnInteract(InteractionType type)
		{
			Player.PlayerBehaviour.Instance.Inventory.AddItem(item, 1);
			Destroy(gameObject);
		}

		/// <summary>
		/// Callback to validate the interaction
		/// </summary>
		/// <param name="type">type of the iteraction</param>
		/// <returns></returns>
		public override bool ValidateInteraction(InteractionType type)
		{
			return type == InteractionType.Main;
		}
	}
}