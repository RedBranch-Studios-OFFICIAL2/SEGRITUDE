using Segritude.InputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		#endregion

		#region Serialized Properties

		/// <summary>
		/// Type of the crop.
		/// See <see cref="CropType"/>
		/// </summary>
		[SerializeField] CropType _Type;

		#endregion

		#region Private Properties

		private float CurrentGrowthRate { get { return Type.AffectedByTime ? Type.NightMultiplier : 1; } }

		#endregion

		#region Unity Callbacks

		private void Update()
		{
			if (GrowthState < Type.GrowthTime)
				GrowthState += CurrentGrowthRate;
			if (InputManager.IntaractDown) ;
				//TODO : Add inventory integration
		}

		#endregion

	}
}
