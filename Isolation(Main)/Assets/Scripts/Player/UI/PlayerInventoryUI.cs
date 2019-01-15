using Segritude.Inventory;
using Segritude.Inventory.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		#endregion

		#region Serialized Fields

		[SerializeField] private PlayerToolbarSlotUI[] toolbar;
		[SerializeField] private GameObject inventoryPanel;
		[SerializeField] private TextMeshProUGUI weightCounter;

		#endregion

		#region Private Fields

		private bool open = true;

		#endregion

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

		#endregion

		#region Public Methods

		public override void UpdateUI(Inventory.Inventory inventory)
		{
			base.UpdateUI(inventory);
			for (int i = 0; i < toolbar.Length; i++)
				toolbar[i].Stack = Player.Instance.ToolBar[i];
			weightCounter.text = $"{ (Holder.Inventory.TotalWeight + Player.Instance.ToolBar.Where(x => !(x is null)).Sum(x => x.Quantity * x.Item.Weight)) / 10f} / {Player.Instance.MaxWeight / 10f}";
		}

		#endregion



	}
}
