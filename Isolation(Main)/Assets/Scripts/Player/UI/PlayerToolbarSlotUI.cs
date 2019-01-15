using Segritude.Inventory.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Segritude.Player.UI
{
	public class PlayerToolbarSlotUI : InventorySlotUI
	{
		public override void OnDrop(PointerEventData eventData)
		{
			if (Stack is null)
			{
				Stack = InventoryUI.CurrentDrag;
				InventoryUI.CurrentDrag = null;
				Player.Instance.ToolBar[Index] = Stack;
				Manager.UpdateUI();
			}
			else
			{
				var previous = Stack;
				Stack = InventoryUI.CurrentDrag;
				InventoryUI.CurrentDrag = null;
				Player.Instance.ToolBar[Index] = Stack;
				Player.Instance.Inventory.AddItem(previous);
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			ReturnDragSprite();
			if (InventoryUI.CurrentDrag is null)
			{
				InventoryUI.CurrentDrag = null;
				Stack = null;
				Player.Instance.ToolBar[Index] = null;
				Manager.UpdateUI();
			}

		}
	}
}