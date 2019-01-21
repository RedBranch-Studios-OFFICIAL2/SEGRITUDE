using UnityEngine;

namespace Segritude.Inventory.Items
{
	/// <summary>
	/// Base class for all item behaviours
	/// </summary>
	public class ItemBehaviour : MonoBehaviour
	{
		#region Public Properties

		/// <summary>
		/// Data about the item
		/// </summary>
		public Item Item { get; set; }

		#endregion Public Properties

		#region Public Methods

		/// <summary>
		/// Called when the item is selected
		/// </summary>
		public virtual void OnSelectItem()
		{
		}

		/// <summary>
		/// Called when the item is deselected
		/// </summary>
		public virtual void OnDeselectItem()
		{

		}

		#endregion Public Methods
	}
}