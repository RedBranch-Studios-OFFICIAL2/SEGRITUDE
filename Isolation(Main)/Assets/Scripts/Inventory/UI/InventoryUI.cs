using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Segritude.Inventory.UI
{
	public class InventoryUI : MonoBehaviour, IDropHandler
	{
		#region Public Properties

		public static ItemStack CurrentDrag { get; set; }

		public IInventoryHolder Holder
		{
			get => holder;
			set
			{
				if (holder == value)
					return;
				holder = value;
				holder.Inventory.OnChange += UpdateUI;
				UpdateUI(holder.Inventory);
			}
		}

		public RectTransform DragParent => dragParent;

		#endregion Public Properties

		#region Serialized Fields

		[SerializeField] private InventorySlotUI slotPrefab;
		[SerializeField] private RectTransform dragParent;

		#endregion Serialized Fields

		#region Private Fields

		private List<InventorySlotUI> inventorySlots = new List<InventorySlotUI>();
		private IInventoryHolder holder;

		#endregion Private Fields

		public virtual void UpdateUI()
		{
			UpdateUI(Holder.Inventory);
		}

		public virtual void UpdateUI(Inventory inventory)
		{
			for (int i = 0; i < inventory.Count; i++)
			{
				if (i < inventorySlots.Count)
				{
					inventorySlots[i].Stack = inventory[i];
					continue;
				}
				var slot = Instantiate(slotPrefab);
				slot.Stack = inventory[i];
				slot.transform.SetParent(transform);
				slot.Manager = this;
				slot.Index = i;
				inventorySlots.Add(slot);
			}
			for (int i = inventory.Count; i < inventorySlots.Count; i++)
			{
				inventorySlots.Remove(transform.GetChild(i).GetComponent<InventorySlotUI>());
				Destroy(transform.GetChild(i).gameObject);
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			Holder.Inventory.AddItem(CurrentDrag);
			CurrentDrag = null;
			UpdateUI();
		}
	}
}