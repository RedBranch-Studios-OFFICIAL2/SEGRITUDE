using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Segritude.Database
{
	public class DatabaseLoader : MonoBehaviour
	{
		private void Start()
		{
			RegisterAllTypes();
		}

		private void RegisterAllTypes()
		{
			var types = Assembly.GetExecutingAssembly().GetTypes().Where(x =>
			x.IsClass &&
			!x.IsAbstract &&
			x.GetInterfaces().Contains(typeof(IDatabaseItem)));

			foreach (var type in types)
			{
				var items = Resources.LoadAll($"Database/{type.Name}", type).Cast<IDatabaseItem>();
				Database.AddDatabase(items, type);
			}
		}
	}
}