using UnityEngine;

namespace Segritude.Inventory
{
	public class Equipement : Item
	{
		#region Public Properties

		/// <summary>
		/// Type of the equipment
		/// </summary>
		public EquipementType Type => type;

		/// <summary>
		/// How much armour does the equipment give
		/// </summary>
		public int Armour => armour;

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Type of the equipment
		/// </summary>
		[SerializeField] private EquipementType type;

		/// <summary>
		/// How much armour does the equipment give
		/// </summary>
		[SerializeField] private int armour;

		#endregion Serialized Fields
	}
}