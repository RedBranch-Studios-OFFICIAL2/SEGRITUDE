using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Segritude.Database
{
	/// <summary>
	/// The base class for databases, not really user friendly
	/// </summary>
	public class Database : IReadOnlyDictionary<string, IDatabaseItem>
	{
		#region Static Properties

		/// <summary>
		/// All the currently created databases
		/// </summary>
		protected static Dictionary<Type, Database> Databases { get; } = new Dictionary<Type, Database>();

		#endregion Static Properties

		#region Public Properties

		/// <summary>
		/// Type of the database
		/// </summary>
		public Type Type { get; }

		#endregion Public Properties

		#region Protected Properties

		/// <summary>
		/// The items that in the database
		/// </summary>
		protected Dictionary<string, IDatabaseItem> Items { get; } = new Dictionary<string, IDatabaseItem>();

		#endregion Protected Properties

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="items">Items that will be in the database</param>
		/// <param name="type">Type of the database</param>
		public Database(IEnumerable<IDatabaseItem> items, Type type)
		{
			this.Items = items.ToDictionary(x => x.ID, y => y);
			this.Type = type;
		}

		#endregion Constructor

		#region Static Methods

		/// <summary>
		/// Creates new database for list of items and given type
		/// </summary>
		/// <param name="items">Items to be stored in the database</param>
		/// <param name="type">Type of the database</param>
		public static void AddDatabase(IEnumerable<IDatabaseItem> items, Type type)
		{
			Databases.Add(type, new Database(items, type));
		}

		/// <summary>
		/// Gets the database by type
		/// </summary>
		/// <param name="type">Type of the database</param>
		/// <returns>Database of the given type</returns>
		public static Database GetDatabase(Type type)
		{
			return Databases[type];
		}

		#endregion Static Methods

		#region IReadOnlyDictionary Implemetation

		/// <summary>
		/// Indexer for the database
		/// </summary>
		/// <param name="id">Id of the item</param>
		/// <returns></returns>
		public IDatabaseItem this[string id]
		{
			get { return Items[id]; }
		}

		/// <summary>
		/// Ids of the items
		/// </summary>
		public IEnumerable<string> Keys => Items.Keys;

		/// <summary>
		/// The items in the database
		/// </summary>
		public IEnumerable<IDatabaseItem> Values => Items.Values;

		/// <summary>
		/// Number of items in database
		/// </summary>
		public int Count => Items.Count;

		/// <summary>
		/// Does the database contain item of specific id
		/// </summary>
		/// <param name="key">Id of the item</param>
		/// <returns></returns>
		public bool ContainsKey(string key) => Items.ContainsKey(key);

		/// <summary>
		/// Tries to get value. Return true if it was succesful
		/// </summary>
		/// <param name="key">Id of the item</param>
		/// <param name="value">Value asociated with the key</param>
		/// <returns>If the get was succesful</returns>
		public bool TryGetValue(string key, out IDatabaseItem value)
		{
			var result = Items.TryGetValue(key, out value);
			return result;
		}

		/// <summary>
		/// Gets the non-generic enumerator
		/// </summary>
		/// <returns>Non-generic enumerator</returns>
		IEnumerator IEnumerable.GetEnumerator() => Items.Values.GetEnumerator();

		/// <summary>
		/// Gets the generic enumerator
		/// </summary>
		/// <returns>Generic enumerator</returns>
		IEnumerator<KeyValuePair<string, IDatabaseItem>> IEnumerable<KeyValuePair<string, IDatabaseItem>>.GetEnumerator() => Items.GetEnumerator();

		#endregion IReadOnlyDictionary Implemetation
	}
}