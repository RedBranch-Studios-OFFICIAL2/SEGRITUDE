using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Segritude.Inventory.UI
{
	public class InventorySlotUI : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
	{
		#region Public Properties

		public int Index { get; set; }
		public InventoryUI Manager { get; set; }

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

		[SerializeField] private Image itemSprite;

		#endregion Serialized Fields

		#region Private Fields

		protected ItemStack stack;
		private Vector2 offset;

		#endregion Private Fields

		public void OnBeginDrag(PointerEventData eventData)
		{
			AttachDragSprite(eventData.position);
			InventoryUI.CurrentDrag = Stack;
		}

		public void OnDrag(PointerEventData eventData)
		{
			itemSprite.transform.position = eventData.position + offset;
		}

		public virtual void OnDrop(PointerEventData eventData)
		{
			Manager.Holder.Inventory.AddItem(InventoryUI.CurrentDrag);
			Manager.UpdateUI();
			InventoryUI.CurrentDrag = null;
		}

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

		protected void AttachDragSprite(Vector2 position)
		{
			itemSprite.transform.SetParent(Manager.DragParent);
			offset = (Vector2)itemSprite.transform.position - position;
		}

		protected void ReturnDragSprite()
		{
			itemSprite.transform.SetParent(transform);
			itemSprite.transform.localPosition = Vector3.zero;
		}
	}
}