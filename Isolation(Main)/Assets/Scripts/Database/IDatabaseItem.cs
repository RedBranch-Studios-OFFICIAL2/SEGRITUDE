namespace Segritude.Database
{
	/// <summary>
	/// Interface every database items has to have
	/// </summary>
	public interface IDatabaseItem
	{
		/// <summary>
		/// Id of the database item
		/// </summary>
		string ID { get; }
	}
}