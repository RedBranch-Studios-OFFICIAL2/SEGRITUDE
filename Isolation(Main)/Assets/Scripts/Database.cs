using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Segritude
{
	public class Database<T> : Database.Database, IReadOnlyDictionary<string, T> where T : IDatabaseItem
	{
		public Database(IEnumerable<IDatabaseItem> items) : base(items, typeof(T))
		{
		}

		T IReadOnlyDictionary<string, T>.this[string key] => (T)base[key];
		#region Static Part



		public static IReadOnlyDictionary<string, T> Items
		{
			get
			{
				var db = GetDatabase(typeof(T));
				return db.ToDictionary(x => x.Key, y => (T)y.Value);
			}
		}

		IEnumerable<T> IReadOnlyDictionary<string, T>.Values => throw new NotImplementedException();

		public bool TryGetValue(string key, out T value) => throw new NotImplementedException();



		#endregion Static Part

		#region Instance Part





		#region IEnumerable Implementation


		IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
		IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator() => items.Cast<KeyValuePair<string, T>>().GetEnumerator();

		#endregion IEnumerable Implementation

		#endregion Instance Part


	}

}