namespace Segritude.Inventory
{
	/// <summary>
	/// Wrapper for <see cref="Segritude.Inventory.Item"/> that also hold the amount
	/// </summary>
	public class ItemStack
	{
		#region Public Properties

		/// <summary>
		/// Id of the item
		/// </summary>
		public string ID => Item.ID;

		/// <summary>
		/// The type of item
		/// </summary>
		public Item Item { get; private set; }

		/// <summary>
		/// Amount of the item
		/// </summary>
		public int Quantity { get; set; }

		#endregion Public Properties

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="item">Type of the item</param>
		/// <param name="quantity">Amount of the item</param>
		public ItemStack(Item item, int quantity)
		{
			Item = item;
			Quantity = quantity;
		}

		#endregion Constructors
	}
}