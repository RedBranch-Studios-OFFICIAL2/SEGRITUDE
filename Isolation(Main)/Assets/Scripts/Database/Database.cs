using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Segritude.Database
{
	public class Database : IReadOnlyDictionary<string, IDatabaseItem>
	{
		protected static Dictionary<Type, Database> databases = new Dictionary<Type, Database>();

		public static void AddDatabase(IEnumerable<IDatabaseItem> items, Type type)
		{
			databases.Add(type, new Database(items, type));
		}

		public static Database GetDatabase(Type type)
		{
			return databases[type];
		}

		public Database(IEnumerable<IDatabaseItem> items, Type type)
		{
			this.items = items.ToDictionary(x => x.ID, y => y);
			this.type = type;
		}

		protected Dictionary<string, IDatabaseItem> items = new Dictionary<string, IDatabaseItem>();

		protected Type type;

		public IDatabaseItem this[string id]
		{
			get { return items[id]; }
		}

		public IEnumerable<string> Keys => items.Keys;

		public IEnumerable<IDatabaseItem> Values => items.Values;

		public int Count => items.Count;

		public bool ContainsKey(string key) => items.ContainsKey(key);

		public bool TryGetValue(string key, out IDatabaseItem value)
		{
			var result = items.TryGetValue(key, out value);
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator() => items.Values.GetEnumerator();

		IEnumerator<KeyValuePair<string, IDatabaseItem>> IEnumerable<KeyValuePair<string, IDatabaseItem>>.GetEnumerator() => items.GetEnumerator();
	}
}