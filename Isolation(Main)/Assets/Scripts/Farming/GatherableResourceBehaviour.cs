using Segritude.Audio;
using Segritude.Interaction;
using System.Collections.Generic;
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

		public override void OnInteract(InteractionType type)
		{
			// TODO : Add inventory integration

			AudioPlayer.Instance.PlaySound(_Resource.GatherSound);
		}

		public override bool ValidateInteraction(InteractionType type)
		{
			if (_Resource.Tool == Tools.ToolType.Any && type == InteractionType.Main)
				return true;
			if (_Resource.Tool != Tools.ToolType.Any && type == InteractionType.Left)
				return true;
			return false;
		}

		#endregion

	}
}