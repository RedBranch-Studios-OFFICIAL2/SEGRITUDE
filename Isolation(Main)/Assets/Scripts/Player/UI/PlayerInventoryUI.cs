using Segritude.Camera;
using Segritude.Inventory.UI;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Segritude.Player.UI
{
	/// <summary>
	/// Special inventory ui used for player ui
	/// </summary>
	public class PlayerInventoryUI : InventoryUI
	{
		#region Public Properties

		/// <summary>
		/// Is the player inventory currently open
		/// </summary>
		public bool Open
		{
			get => open;
			set
			{
				if (open == value)
					return;
				open = value;
				inventoryPanel.SetActive(open);
				CameraController.UseCamera = !open;
				if (open)
					UpdateUI();
			}
		}

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Toolbar slots
		/// </summary>
		[SerializeField] private PlayerToolbarSlotUI[] toolbar;

		/// <summary>
		/// Inventry panel
		/// </summary>
		[SerializeField] private GameObject inventoryPanel;

		/// <summary>
		/// Weight counter
		/// </summary>
		[SerializeField] private TextMeshProUGUI weightCounter;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// Is the player inventory currently open
		/// </summary>
		private bool open = true;

		#endregion Private Fields

		#region Unity Callbacks

		/// <summary>
		/// Called at the start of the program
		/// </summary>
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

		/// <summary>
		/// Updated the UI with given inventory
		/// </summary>
		/// <param name="inventory">Source inventory</param>
		public override void UpdateUI(Inventory.Inventory inventory)
		{
			base.UpdateUI(inventory);
			for (int i = 0; i < toolbar.Length; i++)
				toolbar[i].Stack = PlayerBehaviour.Instance.ToolBar[i];
			weightCounter.text = $"{ (Holder.Inventory.TotalWeight + PlayerBehaviour.Instance.ToolBar.Where(x => !(x is null)).Sum(x => x.Quantity * x.Item.Weight)) / 10f} / {PlayerBehaviour.Instance.MaxWeight / 10f}";
		}

		#endregion Public Methods
	}
}