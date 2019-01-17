using Segritude.Interaction;
using UnityEngine;

namespace Segritude.Farming
{
	/// <summary>
	/// Behaviour for all gatherable resources
	/// </summary>
	public class GatherableResourceBehaviour : InteractableBehaviour
	{
		#region Serialized Fields

		/// <summary>
		/// Resource yielding from gathering
		/// </summary>
		[SerializeField] private GatherableResource _Resource;

		#endregion Serialized Fields

		#region Abstract Implementation

		/// <summary>
		/// Callback when player succesfully interact with the object
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		public override void OnInteract(InteractionType type)
		{
			Player.PlayerBehaviour.Instance.Inventory.AddItem(_Resource.GatheredResource, 19);

			AudioPlayer.Instance.PlaySound(_Resource.GatherSound);
		}

		/// <summary>
		/// Callback when player tries to interact
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		/// <returns>Was the interaction succesful</returns>
		public override bool ValidateInteraction(InteractionType type)
		{
			if (_Resource.Tool == Tools.ToolType.Any && type == InteractionType.Main)
				return true;
			if (_Resource.Tool != Tools.ToolType.Any && type == InteractionType.Left)
				return true;
			return false;
		}

		#endregion Abstract Implementation
	}
}