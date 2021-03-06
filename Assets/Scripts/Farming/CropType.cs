﻿using UnityEngine;

namespace Segritude.Farming
{
	/// <summary>
	/// Represents all information about crop type
	/// </summary>
	public class CropType : ScriptableObject
	{
		#region Public Properties

		/// <summary>
		/// Name of the crop
		/// </summary>
		public string Name { get { return _Name; } }

		/// <summary>
		/// How much of the item is given when harvested
		/// </summary>
		public int Yield { get { return _Yield; } }

		/// <summary>
		/// How long will the crop grow in seconds
		/// </summary>
		public float GrowthTime { get { return _GrowthTime; } }

		/// <summary>
		/// Is the crop growth rate affected by day/night cycle
		/// </summary>
		public bool AffectedByTime { get { return _AffectedByTime; } }

		/// <summary>
		/// How much is the crop affected by day/night cycle
		/// </summary>
		public float NightMultiplier { get { return _NightMultiplier; } }

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Name of the crop
		/// </summary>
		[SerializeField] private string _Name;

		/// <summary>
		/// How much of the item is given when harvested
		/// </summary>
		[SerializeField] private int _Yield = 1;

		/// <summary>
		/// How long will the crop grow in seconds
		/// </summary>
		[SerializeField] private float _GrowthTime = 1;

		/// <summary>
		/// Is the crop growth rate affected by day/night cycle
		/// </summary>
		[SerializeField] private bool _AffectedByTime = true;

		/// <summary>
		/// How much is the crop affected by day/night cycle
		/// </summary>
		[SerializeField] private float _NightMultiplier = 0.5f;

		#endregion Serialized Fields
	}
}