using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Segritude.Inventory
{
	public class Inventory : IEnumerable<ItemStack>
	{
		#region Public Events

		/// <summary>
		/// Event called when something an item is added or removed from inventory
		/// </summary>
		public event Action<Inventory> OnChange;

		#endregion Public Events

		#region Public Properties

		/// <summary>
		/// Amount of different items in the inventory
		/// </summary>
		public int Count => items.Count;

		/// <summary>
		/// Amount of items in the inventory
		/// </summary>
		public int TotalCount => items.Sum(x => x.Quantity);

		/// <summary>
		/// Total weight of the items in the inventory
		/// </summary>
		public int TotalWeight => items.Sum(x => x.Quantity * Database<Item>.Items[x.ID].Weight);

		#endregion Public Properties

		#region Private Fields

		private List<ItemStack> items = new List<ItemStack>();

		#endregion Private Fields

		#region Public Methods

		/// <summary>
		/// The default indexer
		/// </summary>
		/// <param name="index">Index in the inventory</param>
		/// <returns>The <see cref="ItemStack"/> in this slot</returns>
		public ItemStack this[int index] => items[index];

		/// <summary>
		/// The indexer for checking how much of given item the inventory has
		/// </summary>
		/// <param name="id">Id of the item</param>
		/// <returns></returns>
		public int this[string id] => items.Where(x => x.ID == id).Sum(x => x.Quantity);

		/// <summary>
		/// Add an item to inventory
		/// </summary>
		/// <param name="stack">Stack of the item</param>
		public void AddItem(ItemStack stack)
		{
			AddItem(stack.ID, stack.Quantity);
		}

		/// <summary>
		/// Add an item to inventory
		/// </summary>
		/// <param name="id">Id of the item</param>
		/// <param name="amount">amount of the item</param>
		public void AddItem(string id, int amount)
		{
			AddItem(Database<Item>.Items[id], amount);
		}

		/// <summary>
		/// Add an item to inventory
		/// </summary>
		/// <param name="item">Item to be added</param>
		/// <param name="amount">amount of the item</param>
		public void AddItem(Item item, int amount)
		{
			if (amount <= 0 || item is null)
				return;
			for (int i = 0; amount > 0 && i < Count; i++)
			{
				var itemStack = items[i];
				if (itemStack.ID != item.ID)
					continue;
				var spaceLeft = itemStack.Item.MaxAmount - itemStack.Quantity;
				var count = Math.Min(spaceLeft, amount);
				items[i].Quantity += count;
				amount -= count;
			}
			if (amount > 0)
				items.Add(new ItemStack(item, amount));
			OnChange?.Invoke(this);
		}

		/// <summary>
		/// Removes set amount of the item from inventory
		/// </summary>
		/// <param name="id">Id of the item</param>
		/// <param name="amount">Amount to be removed</param>
		/// <returns>How much of the item was actually removed</returns>
		public int RemoveItem(string id, int amount)
		{
			return RemoveItem(Database<Item>.Items[id], amount);
		}

		/// <summary>
		/// Removes set amount of the item from inventory
		/// </summary>
		/// <param name="item">Item to be removed</param>
		/// <param name="amount">Amount to be removed</param>
		/// <returns>How much of the item was actually removed</returns>
		public int RemoveItem(Item item, int amount)
		{
			var taken = 0;
			if (amount <= 0)
				return 0;
			OnChange?.Invoke(this);
			for (int i = 0; amount > 0 && i < Count; i++)
			{
				var itemStack = items[i];
				if (itemStack.ID != item.ID)
					continue;

				var count = Math.Min(itemStack.Quantity, amount);
				items[i].Quantity -= count;
				amount -= count;
				taken += count;
				if (items[i].Quantity <= 0)
				{
					items.RemoveAt(i);
					i--;
				}
			}
			return taken;
		}

		/// <summary>
		/// Does the inventory contain set amount of item
		/// </summary>
		/// <param name="item">Id of the item to check</param>
		/// <param name="amount">Amount that the item. Leave empty for any</param>
		/// <returns></returns>
		public bool HasItem(string item, int amount = 0)
		{
			return items.Any(x => x.ID == item) && items.Where(x => x.ID == item).Sum(x => x.Quantity) > amount;
		}

		/// <summary>
		/// Does the inventory contain set amount of item
		/// </summary>
		/// <param name="item">The item to check</param>
		/// <param name="amount">Amount that the item. Leave empty for any</param>
		/// <returns></returns>
		public bool HasItem(Item item, int amount = 0)
		{
			return HasItem(item.ID, amount);
		}

		/// <summary>
		/// Removes whole stack from inventory
		/// </summary>
		/// <param name="index">Index of the inventory</param>
		/// <returns>Stack that was removed</returns>
		public ItemStack RemoveStack(int index)
		{
			var stack = items[index];
			items.RemoveAt(index);
			return stack;
		}

		#endregion Public Methods

		#region IEnumerable implementaion

		public IEnumerator<ItemStack> GetEnumerator() => items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

		#endregion IEnumerable implementaion
	}
}