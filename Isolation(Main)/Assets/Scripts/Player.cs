using Segritude;
using Segritude.Health;
using Segritude.Inventory;
using Segritude.Inventory.UI;
using UnityEngine;

public class Player : GlobalBehaviour<Player>, ILivingCreature
{
	#region Public Properties

	public int Health { get; private set; }
	public int Hunger { get; private set; }
	public int Thirst { get; private set; }
	public int Stamina { get; private set; }

	public Inventory Inventory { get; private set; }
	public ItemStack[] ToolBar { get; private set; }

	#endregion Public Properties

	#region Serialized Fields

	[SerializeField] private Vector2Int hungerChangeRange = new Vector2Int(0, 5);
	[SerializeField] private float hungerProbabilityChangeRate = 0.1f;

	[SerializeField] private Vector2Int thirstChangeRange = new Vector2Int(0, 5);
	[SerializeField] private float thirstProbabilityChangeRate = 0.1f;

	[SerializeField] private int StaminaRegenration = 1;

	#endregion Serialized Fields

	#region Private Fields

	private float hungerChangeChance = 0;
	private float thirstChangeChance = 0;

	#endregion Private Fields

	#region Unity Callbacks

	public void Start()
	{
		Inventory = new Inventory();
		Inventory.OnChange += UpdateUI;
		ToolBar = new ItemStack[7];
	}

	private void Update()
	{
		GetHungryAndThirsty();
		CalculateStamina();
	}

	#endregion Unity Callbacks

	#region Public Methods

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

	private static void UpdateUI(Inventory obj)
	{
		InventoryUI.UpdateUI();
	}

	private void CalculateStamina()
	{
		if (Stamina < 100)
			Stamina += StaminaRegenration;
	}

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

	#endregion Private Methods
}