using Segritude.Inventory.UI;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Segritude.Player.UI
{
	public class PlayerInventoryUI : InventoryUI
	{
		#region Public Properties

		public bool Open
		{
			get => open;
			set
			{
				if (open == value)
					return;
				open = value;
				inventoryPanel.SetActive(open);
				if (open)
					UpdateUI();
			}
		}

		#endregion Public Properties

		#region Serialized Fields

		[SerializeField] private PlayerToolbarSlotUI[] toolbar;
		[SerializeField] private GameObject inventoryPanel;
		[SerializeField] private TextMeshProUGUI weightCounter;

		#endregion Serialized Fields

		#region Private Fields

		private bool open = true;

		#endregion Private Fields

		#region Unity Callbacks

		private void Start()
		{
			for (int i = 0; i < toolbar.Length; i++)
			{
				toolbar[i].Index = i;
				toolbar[i].Manager = this;
			}
			Open = false;
		}

		#endregion Unity Callbacks

		#region Public Methods

		public override void UpdateUI(Inventory.Inventory inventory)
		{
			base.UpdateUI(inventory);
			for (int i = 0; i < toolbar.Length; i++)
				toolbar[i].Stack = Player.Instance.ToolBar[i];
			weightCounter.text = $"{ (Holder.Inventory.TotalWeight + Player.Instance.ToolBar.Where(x => !(x is null)).Sum(x => x.Quantity * x.Item.Weight)) / 10f} / {Player.Instance.MaxWeight / 10f}";
		}

		#endregion Public Methods
	}
}