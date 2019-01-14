using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segritude.Inventory
{
	public class ItemStack
	{
		public string ID => Item.ID;

		public Item Item { get; private set;}
		public int Quantity { get; set; }

		public ItemStack(Item item, int quantity)
		{
			Item = item;
			Quantity = quantity;
		}
	}
}
