using Segritude.Tools;
using UnityEngine;

namespace Segritude.Farming
{
	/// <summary>
	/// Representa all the date about certain gatherable resource
	/// </summary>
	public class GatherableResource : ScriptableObject
	{
		#region Public Properties

		/// <summary>
		/// Name of the resource
		/// </summary>
		public string Name { get { return _Name; } }

		/// <summary>
		/// Sound that plays when the resource is gathered
		/// </summary>
		public AudioClip GatherSound { get { return _GatherSound; } }

		/// <summary>
		/// <see cref="ToolType"/> of tool required to gather this resource
		/// </summary>
		public ToolType Tool { get { return _Tool; } }

		#endregion Public Properties

		#region Serizalizable Fields

		/// <summary>
		/// Name of the resource
		/// </summary>
		[SerializeField] private string _Name;

		/// <summary>
		/// Sound that plays when the resource is gathered
		/// </summary>
		[SerializeField] private AudioClip _GatherSound;

		/// <summary>
		/// <see cref="ToolType"/> of tool required to gather this resource
		/// </summary>
		[SerializeField] private ToolType _Tool;

		#endregion Serizalizable Fields
	}
}