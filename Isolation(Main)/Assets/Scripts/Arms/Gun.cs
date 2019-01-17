using Segritude.Inventory;
using UnityEngine;

namespace Segritude.Arms
{
	[CreateAssetMenu(menuName = "Inventory/Gun")]
	public class Gun : Item
	{
		#region Public Property

		public float Range => fireRate;

		public Vector2 MaximalRecoil => maximalRecoil;

		#endregion Public Property

		#region Serialized Fields

		[SerializeField] private float fireRate = 1;
		[SerializeField] private Vector2 maximalRecoil = Vector2.one;

		#endregion Serialized Fields
	}
}