namespace Segritude.Health
{
	/// <summary>
	/// Base interface for all living objects
	/// </summary>
	public interface ILivingCreature
	{
		/// <summary>
		/// Current health
		/// </summary>
		int Health { get; }

		/// <summary>
		/// Methods used to apllaying damage
		/// </summary>
		/// <param name="damage">The amount of damage</param>
		/// <param name="source">The source of the damage</param>
		/// <returns>Is the target dead</returns>
		bool TakeDamage(int damage, IDamageSource source);
	}
}