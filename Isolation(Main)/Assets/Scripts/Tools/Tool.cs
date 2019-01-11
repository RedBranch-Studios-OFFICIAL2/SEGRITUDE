using UnityEngine;

namespace Segritude.Tools
{
	/// <summary>
	/// Represents all information about specific tool
	/// </summary>
	public class Tool : ScriptableObject
	{
		#region Public Properties

		/// <summary>
		/// Name of the tool
		/// </summary>
		public string Name { get { return _Name; } }

		/// <summary>
		/// Type of the tool
		/// </summary>
		public ToolType Type { get { return _Type; } }

		/// <summary>
		/// How many uses does the tool have
		/// </summary>
		public float Durability { get { return _Durability; } }

		/// <summary>
		/// How fast is the tool gathering resource
		/// </summary>
		public Vector2 Yield { get { return _Yield; } }

		#endregion Public Properties

		#region Serialized Fields

		/// <summary>
		/// Name of the tool
		/// </summary>
		[SerializeField] private string _Name = "";

		/// <summary>
		/// Type of the tool
		/// </summary>
		[SerializeField] private ToolType _Type;

		/// <summary>
		/// How many uses does the tool have
		/// </summary>
		[SerializeField] private float _Durability = 1;

		/// <summary>
		/// How fast is the tool gathering resource
		/// </summary>
		[SerializeField] private Vector2 _Yield = new Vector2(0, 10);

		#endregion Serialized Fields
	}
}