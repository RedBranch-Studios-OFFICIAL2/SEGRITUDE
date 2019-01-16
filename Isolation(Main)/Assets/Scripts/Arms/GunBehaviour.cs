using Segritude.Interaction;
using System;
using UnityEngine;

namespace Segritude.Arms
{
	public class GunBehaviour : MonoBehaviour, IInteractable
	{
		#region Serialized Fields

		[SerializeField] private Gun gun;

		#endregion Serialized Fields

		public void EndInteraction(InteractionType type) => throw new NotImplementedException();

		public void StartInteraction(InteractionType type) => throw new NotImplementedException();

		public bool ValidateInteraction(InteractionType type) => throw new NotImplementedException();
	}
}