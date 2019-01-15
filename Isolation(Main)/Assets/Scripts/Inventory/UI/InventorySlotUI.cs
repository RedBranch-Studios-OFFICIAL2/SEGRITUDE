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
				sprite.sprite = stack?.Item.Sprite ?? null;
				dragSprite.sprite = stack?.Item.Sprite ?? null;
			}
		}

		#endregion

		#region Serialized Fields

		[SerializeField] private Image sprite;
		[SerializeField] private Image dragSprite;

		#endregion Serialized Fields

		#region Private Properties

		protected bool IsDragging
		{
			get => isDragging;
			set
			{
				if (isDragging == value)
					return;
				isDragging = value;
				sprite.gameObject.SetActive(isDragging ^ true);
			}
		}

		#endregion Public Properties

		#region Private Fields

		protected ItemStack stack;
		private Vector2 offset;
		private bool isDragging;

		#endregion Private Fields



		public void OnBeginDrag(PointerEventData eventData)
		{
			AttachDragSprite(eventData.position);
			InventoryUI.CurrentDrag = Stack;
			
		}
		public void OnDrag(PointerEventData eventData)
		{
			dragSprite.transform.position = eventData.position + offset;
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
			isDragging = true;
			dragSprite.transform.SetParent(Manager.DragParent);
			offset = (Vector2)dragSprite.transform.position - position;
			dragSprite.gameObject.SetActive(true);
		}

		protected void ReturnDragSprite()
		{
			isDragging = false;
			dragSprite.transform.SetParent(transform);
			dragSprite.transform.localPosition = Vector3.zero;
			dragSprite.gameObject.SetActive(false);
		}
	}
}