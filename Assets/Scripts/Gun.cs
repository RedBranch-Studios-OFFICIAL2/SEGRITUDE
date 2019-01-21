using System.Collections;
using Segritude.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Segritude.Arms
{

	[CreateAssetMenu(menuName = "Inventory/Gun")]
	public class Gun : Item
	{
		#region PublicProperties

		public int Damage => damage;
		public int Range => range;

		public int MaxClip => maxClip;

		public int FireRate => fireRate;
		public bool Automatic => automatic;

		#endregion

		#region SerializedFields

		[SerializeField] private int damage = 10;
		[SerializeField] private int range = 150;

		[SerializeField] private int maxClip = 32;

		[SerializeField] private int fireRate;
		[SerializeField] private bool automatic;


		#endregion
	}
}