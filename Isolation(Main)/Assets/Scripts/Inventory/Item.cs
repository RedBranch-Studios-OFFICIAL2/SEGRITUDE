using Segritude.Database;
using UnityEngine;

namespace Segritude.Inventory
{
	[CreateAssetMenu(menuName = "Inventory/Item")]
	public class Item : ScriptableObject, IDatabaseItem
	{
		#region Public Properties

		/// <summary>
		/// Id of the item
		/// </summary>
		public string ID => base.name;

		/// <summary>
		/// Name of the item
		/// </summary>
		public string Name => string.IsNullOrWhiteSpace(customName) ? ID : customName;

		/// <summary>
		/// Weight of the item
		/// </summary>
		public int Weight => weight;

		/// <summary>
		/// Sprite displayed in the inventory
		/// </summary>
		public Sprite Sprite => sprite;

		/// <summary>
		/// Maximal amount per stack
		/// </summary>
		public int MaxAmount => maxAmountPerStack;

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Custom name for the item (optional)
		/// </summary>
		[Tooltip("Optional")] [SerializeField] private string customName;

		/// <summary>
		/// Weight of the item
		/// </summary>
		[SerializeField] private int weight = 1;

		/// <summary>
		/// Sprite displayed in the inventory
		/// </summary>
		[SerializeField] private Sprite sprite;

		/// <summary>
		/// Maximal amount per stack
		/// </summary>
		[SerializeField] private int maxAmountPerStack = 1;

		#endregion Serialized Fields
	}
}