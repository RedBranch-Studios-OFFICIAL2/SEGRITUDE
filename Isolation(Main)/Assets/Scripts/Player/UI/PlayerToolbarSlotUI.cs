using Segritude.Inventory.UI;
using UnityEngine.EventSystems;

namespace Segritude.Player.UI
{
	/// <summary>
	/// Special slot ui used for player toolbar
	/// </summary>
	public class PlayerToolbarSlotUI : InventorySlotUI
	{
		#region IDragHandler Callbacks

		/// <summary>
		/// Called when an item is dropped into the slot
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnDrop(PointerEventData eventData)
		{
			if (Stack is null)
			{
				Stack = InventoryUI.CurrentDrag;
				InventoryUI.CurrentDrag = null;
				PlayerBehaviour.Instance.ToolBar[Index] = Stack;
				Manager.UpdateUI();
			}
			else
			{
				var previous = Stack;
				Stack = InventoryUI.CurrentDrag;
				InventoryUI.CurrentDrag = null;
				PlayerBehaviour.Instance.ToolBar[Index] = Stack;
				PlayerBehaviour.Instance.Inventory.AddItem(previous);
			}
			if (Index == PlayerBehaviour.Instance.SelectedToolBarSlot)
				PlayerBehaviour.Instance.UpdateCurrentSlot();
		}

		/// <summary>
		/// Called at the end of the drag
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnEndDrag(PointerEventData eventData)
		{
			ReturnDragSprite();
			if (InventoryUI.CurrentDrag is null)
			{
				InventoryUI.CurrentDrag = null;
				Stack = null;
				PlayerBehaviour.Instance.ToolBar[Index] = null;
				Manager.UpdateUI();
			}
		}

		#endregion IDragHandler Callbacks
	}
}