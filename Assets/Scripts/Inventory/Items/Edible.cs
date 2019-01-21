using UnityEngine;

namespace Segritude.Inventory.Items
{
	[CreateAssetMenu(menuName = "Inventory/Edible")]
	public class Edible : Item
	{
		public float EatTime => eatTime;
		public int HealthGain => healthGain;
		public int HungerGain => hungerGain;
		public int ThirstGain => thirstGain;
		public int StaminaGain => staminaGain;

		[SerializeField] private float eatTime;
		[SerializeField] private int healthGain;
		[SerializeField] private int hungerGain;
		[SerializeField] private int thirstGain;
		[SerializeField] private int staminaGain;
	}
}