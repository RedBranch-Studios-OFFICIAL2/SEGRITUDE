using UnityEngine;

namespace Segritude.Farming
{
	/// <summary>
	/// Behaviour for crops
	/// </summary>
	public class CropBehaviour : MonoBehaviour
	{
		#region Public Properties

		/// <summary>
		/// Current growth state. Crop is grown when <see cref="GrowthState"/> reaches <see cref="CropType.GrowthTime"/>
		/// </summary>
		public float GrowthState { get; private set; }

		/// <summary>
		/// Type of the crop.
		/// See <see cref="CropType"/>
		/// </summary>
		public CropType Type { get { return _Type; } }

		#endregion Public Properties

		#region Serialized Properties

		/// <summary>
		/// Type of the crop.
		/// See <see cref="CropType"/>
		/// </summary>
		[SerializeField] private CropType _Type;

		#endregion Serialized Properties

		#region Private Properties

		private float CurrentGrowthRate { get { return Type.AffectedByTime ? Type.NightMultiplier : 1; } }

		#endregion Private Properties

		#region Unity Callbacks

		private void Update()
		{
			if (GrowthState < Type.GrowthTime)
				GrowthState += CurrentGrowthRate;
			if (InputManager.InteractMainDown) ;
			//TODO : Add inventory integration
		}

		#endregion Unity Callbacks
	}
}