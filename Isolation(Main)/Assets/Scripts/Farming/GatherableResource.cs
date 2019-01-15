using Segritude.Inventory;
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
		public string Name => _Name;

		/// <summary>
		/// Sound that plays when the resource is gathered
		/// </summary>
		public AudioClip GatherSound => _GatherSound;

		/// <summary>
		/// <see cref="ToolType"/> of tool required to gather this resource
		/// </summary>
		public ToolType Tool => _Tool;

		/// <summary>
		/// Item that is gathered
		/// </summary>
		public Item GatheredResource => _GatheredResource;

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

		/// <summary>
		/// Item that is gathered
		/// </summary>
		[SerializeField] private Item _GatheredResource;

		#endregion Serizalizable Fields
	}
}