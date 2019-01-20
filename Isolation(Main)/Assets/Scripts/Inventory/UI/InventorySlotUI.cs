using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Segritude.Inventory.UI
{
	public class InventorySlotUI : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
	{
		#region Public Properties

		/// <summary>
		/// Index of the slot in the inventory
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// <see cref="InventoryUI"/> that manages this slot
		/// </summary>
		public InventoryUI Manager { get; set; }

		/// <summary>
		/// Stack currently in this slot
		/// </summary>
		public ItemStack Stack
		{
			get
			{
				return stack;
			}
			set
			{
				if (stack == value)
					return;
				stack = value;
				itemSprite.sprite = stack?.Item.Sprite ?? null;
			}
		}

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Image that will show the <see cref="Item.Sprite"/>
		/// </summary>
		[SerializeField] private Image itemSprite;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// Stack currently in this slot
		/// </summary>
		protected ItemStack stack;

		/// <summary>
		/// Offset releative to the mouse
		/// </summary>
		private Vector2 offset;

		#endregion Private Fields

		#region IDragHandler Callbacks


		/// <summary>
		/// Called at the start of the drag
		/// </summary>
		/// <param name="eventData"></param>
		public void OnBeginDrag(PointerEventData eventData)
		{
			AttachDragSprite(eventData.position);
			InventoryUI.CurrentDrag = Stack;
		}

		/// <summary>
		/// Called every frame of the deag
		/// </summary>
		/// <param name="eventData"></param>
		public void OnDrag(PointerEventData eventData)
		{
			itemSprite.transform.position = eventData.position + offset;
		}

		/// <summary>
		/// Called when an item is dropped into the slot
		/// </summary>
		/// <param name="eventData"></param>
		public virtual void OnDrop(PointerEventData eventData)
		{
			Manager.Holder.Inventory.AddItem(InventoryUI.CurrentDrag);
			Manager.UpdateUI();
			InventoryUI.CurrentDrag = null;
		}

		/// <summary>
		/// Called at the end to the drag
		/// </summary>
		/// <param name="eventData"></param>
		public virtual void OnEndDrag(PointerEventData eventData)
		{
			ReturnDragSprite();
			if (InventoryUI.CurrentDrag is null)
			{
				InventoryUI.CurrentDrag = null;
				Stack = null;
				Manager.Holder.Inventory.RemoveStack(Index);
				Manager.UpdateUI();
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Call to start to drag the sprite
		/// </summary>
		/// <param name="position">Position of the mouse</param>
		protected void AttachDragSprite(Vector2 position)
		{
			itemSprite.transform.SetParent(Manager.DragParent);
			offset = (Vector2)itemSprite.transform.position - position;
		}

		/// <summary>
		/// Call to return the sprite to the slot
		/// </summary>
		protected void ReturnDragSprite()
		{
			itemSprite.transform.SetParent(transform);
			itemSprite.transform.localPosition = Vector3.zero;
		}

		#endregion
	}
}