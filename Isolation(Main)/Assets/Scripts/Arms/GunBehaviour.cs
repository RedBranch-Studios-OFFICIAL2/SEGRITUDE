using Segritude.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Segritude.Arms
{
	public class GunBehaviour : MonoBehaviour, IInteractable
	{
		#region Public Properties

		#endregion

		#region Serialized Fields

		[SerializeField] private Gun gun;

		#endregion

		public void EndInteraction(InteractionType type) => throw new NotImplementedException();
		public void StartInteraction(InteractionType type) => throw new NotImplementedException();
		public bool ValidateInteraction(InteractionType type) => throw new NotImplementedException();
	}
}
