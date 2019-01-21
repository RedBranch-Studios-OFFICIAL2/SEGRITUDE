using Segritude.Database;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Segritude
{
	/// <summary>
	/// Wrapper class for <see cref="Segritude.Database.Database"/> for ease of use
	/// </summary>
	/// <typeparam name="T">Type of the database</typeparam>
	public class Database<T> : Database.Database, IReadOnlyDictionary<string, T> where T : IDatabaseItem
	{
		#region Static Properties

		/// <summary>
		/// Default way do access the items
		/// </summary>
		public static IReadOnlyDictionary<string, T> Items
		{
			get
			{
				var db = GetDatabase(typeof(T));
				return db.ToDictionary(x => x.Key, y => (T)y.Value);
			}
		}

		#endregion Static Properties

		#region Constructors

		/// <summary>
		/// Default constructor for the database
		/// </summary>
		/// <param name="items"></param>
		public Database(IEnumerable<T> items) : base(items.Cast<IDatabaseItem>(), typeof(T))
		{
		}

		#endregion Constructors

		#region IReadOnlyDictionary Implementation

		/// <summary>
		/// Tries to get value. Return true if it was succesful
		/// </summary>
		/// <param name="key">Key of the item</param>
		/// <param name="value">Value asociated with the key</param>
		/// <returns>If the get was succesful</returns>
		public bool TryGetValue(string key, out T value)
		{
			var result = base.Items.TryGetValue(key, out var v);
			value = (T)v;
			return result;
		}

		/// <summary>
		/// Default indexer
		/// </summary>
		/// <param name="key">Key of the item</param>
		/// <returns>Item asociated with the key</returns>
		T IReadOnlyDictionary<string, T>.this[string key] => (T)base[key];

		/// <summary>
		/// Gets all the Values in dictionary
		/// </summary>
		IEnumerable<T> IReadOnlyDictionary<string, T>.Values => base.Items.Values.Cast<T>();

		/// <summary>
		/// Get the non-generic enumerator
		/// </summary>
		/// <returns>Non-generic enumerator</returns>
		IEnumerator IEnumerable.GetEnumerator() => base.Items.GetEnumerator();

		/// <summary>
		/// Gets the generic enumerator
		/// </summary>
		/// <returns>Generic enumerator</returns>
		IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() => base.Items.Cast<KeyValuePair<string, T>>().GetEnumerator();

		#endregion IReadOnlyDictionary Implementation
	}
}