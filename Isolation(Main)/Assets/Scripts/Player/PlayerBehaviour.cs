using Segritude.Health;
using Segritude.Inventory;
using Segritude.Player.UI;
using UnityEngine;

namespace Segritude.Player
{
	public class PlayerBehaviour : GlobalBehaviour<PlayerBehaviour>, ILivingCreature, IInventoryHolder
	{
		#region Public Properties

		/// <summary>
		/// Current health of the player
		/// </summary>
		public int Health { get; private set; }

		/// <summary>
		/// Current hunger of the player
		/// </summary>
		public int Hunger { get; private set; }

		/// <summary>
		/// Current thirst of the player
		/// </summary>
		public int Thirst { get; private set; }

		/// <summary>
		/// Current staminga of the player
		/// </summary>
		public int Stamina { get; private set; }

		/// <summary>
		/// Inventory of the player
		/// </summary>
		public Inventory.Inventory Inventory { get; private set; }

		/// <summary>
		/// Items in the toolbar
		/// </summary>
		public ItemStack[] ToolBar { get; private set; }

		/// <summary>
		/// Which item from toolbar is currently selected
		/// </summary>
		public int SelectedToolBarSlot { get; private set; }

		/// <summary>
		/// Max wieght that the player can carry
		/// </summary>
		public int MaxWeight { get; private set; }

		#endregion Public Properties

		#region Serialized Fields

		[SerializeField] private Vector2Int hungerChangeRange = new Vector2Int(0, 5);
		[SerializeField] private float hungerProbabilityChangeRate = 0.1f;

		[SerializeField] private Vector2Int thirstChangeRange = new Vector2Int(0, 5);
		[SerializeField] private float thirstProbabilityChangeRate = 0.1f;

		[SerializeField] private int StaminaRegenration = 1;

		[SerializeField] private PlayerInventoryUI InventoryUI;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// Current chance for player to get more hungry
		/// </summary>
		private float hungerChangeChance = 0;

		/// <summary>
		/// Current chance for player to get more thirsty
		/// </summary>
		private float thirstChangeChance = 0;

		#endregion Private Fields

		#region Unity Callbacks

		public void Start()
		{
			ToolBar = new ItemStack[10];
			Inventory = new Inventory.Inventory();
			InventoryUI.Holder = this;
			Inventory.AddItem(Database<Item>.Items["Apple"], 1);
		}

		private void Update()
		{
			GetHungryAndThirsty();
			CalculateStamina();
			UpdateSelectedSlot();
			if (InputManager.InventoryDown)
				InventoryUI.Open ^= true;
		}

		#endregion Unity Callbacks

		#region Public Methods

		/// <summary>
		/// Implementation of the <see cref="ILivingCreature"/> interaface
		/// </summary>
		/// <param name="damage">Amount of damage to be applied</param>
		/// <param name="damageSource">Source of the damage</param>
		/// <returns></returns>
		public bool TakeDamage(int damage, IDamageSource damageSource)
		{
			Health -= damage;
			if (Health <= 0)
			{
				//Die
				return true;
			}
			return false;
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Used for calculating current stamina
		/// </summary>
		private void CalculateStamina()
		{
			if (Stamina < 100)
				Stamina += StaminaRegenration;
		}

		/// <summary>
		/// Used for calculating current hunger/thirst levels
		/// </summary>
		private void GetHungryAndThirsty()
		{
			hungerChangeChance += Time.deltaTime * hungerProbabilityChangeRate;
			thirstChangeChance += Time.deltaTime * thirstProbabilityChangeRate;
			if (Random.Range(0f, 1f) < hungerChangeChance)
			{
				Hunger -= Random.Range(hungerChangeRange.x, hungerChangeRange.y);
				hungerChangeChance = 0;
			}
			if (Random.Range(0f, 1f) < thirstChangeChance)
			{
				Thirst -= Random.Range(thirstChangeRange.x, thirstChangeRange.y);
				thirstChangeChance = 0;
			}
		}

		/// <summary>
		/// Used for choosing selected toolbar slot
		/// </summary>
		private void UpdateSelectedSlot()
		{
			for (int i = 0; i < 10; i++)
				if (InputManager.SlotDown(i))
					SelectedToolBarSlot = i;
		}

		#endregion Private Methods
	}
}