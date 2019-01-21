namespace Segritude.Inventory
{
	/// <summary>
	/// Interface for every object that has inventory
	/// </summary>
	public interface IInventoryHolder
	{
		Inventory Inventory { get; }
	}
}