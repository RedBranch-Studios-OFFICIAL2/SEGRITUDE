using UnityEngine;

namespace Segritude
{
	/// <summary>
	/// Hold info about layers
	/// </summary>
	public static class LayerManager
	{
		#region Layers

		/// <summary>
		/// Layer for all interactables
		/// </summary>
		public const int InteractableLayer = 8;

		#endregion Layers

		#region Masks

		/// <summary>
		/// Mask for raycasting interactables
		/// </summary>
		public static LayerMask InteractableMask { get { return 1 << InteractableLayer; } }

		#endregion Masks
	}
}