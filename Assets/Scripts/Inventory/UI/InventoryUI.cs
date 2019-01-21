using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Segritude.Inventory.UI
{
	public class InventoryUI : MonoBehaviour, IDropHandler
	{
		#region Public Properties

		/// <summary>
		/// Item that the player is currently dragging
		/// </summary>
		public static ItemStack CurrentDrag { get; set; }

		/// <summary>
		/// Owner of the inventory
		/// </summary>
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

		/// <summary>
		/// Game object that will hold the dragged item game object
		/// </summary>
		public RectTransform DragParent => dragParent;

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Prefab for the inventory slot
		/// </summary>
		[SerializeField] private InventorySlotUI slotPrefab;

		/// <summary>
		/// Game object that will hold the dragged item game object
		/// </summary>
		[SerializeField] private RectTransform dragParent;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// Slots in the inventory
		/// </summary>
		private List<InventorySlotUI> inventorySlots = new List<InventorySlotUI>();

		/// <summary>
		/// Owner of the inventory
		/// </summary>
		private IInventoryHolder holder;

		#endregion Private Fields

		#region Public Methods

		/// <summary>
		/// Updates UI using <see cref="Holder"/>'s inventory
		/// </summary>
		public virtual void UpdateUI() => UpdateUI(holder.Inventory);

		/// <summary>
		/// Update UI using given inventory
		/// </summary>
		/// <param name="inventory">Srouce inventory</param>
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

		/// <summary>
		/// Callback called when item is dropper into the inventory
		/// </summary>
		/// <param name="eventData">Event data</param>
		public void OnDrop(PointerEventData eventData)
		{
			Holder.Inventory.AddItem(CurrentDrag);
			CurrentDrag = null;
			UpdateUI();
		}

		#endregion Public Methods
	}
}