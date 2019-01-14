using Segritude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Segritude.Inventory.UI
{
	public class InventoryUI : GlobalBehaviour<InventoryUI>
	{
		#region Public Properties

		public ItemStack CurrentDrag { get; set; }

		public RectTransform DragParent => dragParent;

		#endregion

		#region Serialized Fields

		[SerializeField] private RectTransform dragParent;
		[SerializeField] private RectTransform inventoryPanel;
		[SerializeField] private InventorySlotUI[] toolbarSlots;
		[SerializeField] private List<InventorySlotUI> inventorySlots;


		#endregion

		internal static void UpdateUI()
		{
			
		}
	}
}
