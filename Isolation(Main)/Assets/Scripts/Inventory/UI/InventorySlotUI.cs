using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Segritude.Inventory.UI
{
	public class InventorySlotUI : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
	{
		#region Serialized Fields

		[SerializeField] private Image sprite;
		[SerializeField] private Image dragSprite;

		#endregion Serialized Fields

		#region Private Fields

		private ItemStack stack;
		private Vector2 Offset;
		private bool IsDragging;

		#endregion Private Fields

		#region Public Properties

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
				sprite.sprite = stack.Item.Sprite;
				if (!IsDragging)
					dragSprite.sprite = stack?.Item.Sprite ?? null;
			}
		}

		#endregion Public Properties

		public void OnBeginDrag(PointerEventData eventData)
		{
			IsDragging = true;
			InventoryUI.Instance.CurrentDrag = Stack;
			Stack = null;
			dragSprite.transform.SetParent(InventoryUI.Instance.DragParent);
			Offset = (Vector2)dragSprite.transform.position - eventData.position;
			dragSprite.gameObject.SetActive(true);

		}
		public void OnDrag(PointerEventData eventData)
		{
			dragSprite.transform.position = eventData.position + Offset;
		}
		public void OnDrop(PointerEventData eventData)
		{
			Stack = InventoryUI.Instance.CurrentDrag;
			InventoryUI.Instance.CurrentDrag = null;
		}
		public void OnEndDrag(PointerEventData eventData)
		{
			IsDragging = false;
			dragSprite.transform.SetParent(transform);
			dragSprite.transform.localPosition = Vector3.zero;
			dragSprite.gameObject.SetActive(false);
			if (InventoryUI.Instance.CurrentDrag is null)
			{
				dragSprite.sprite = null;
			}
			Stack = InventoryUI.Instance.CurrentDrag;
			InventoryUI.Instance.CurrentDrag = null;

		}
	}
}