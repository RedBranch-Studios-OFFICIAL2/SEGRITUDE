using Segritude.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Segritude.Arms
{
	public class Gun : Item
	{
		#region Serialized Fields

		[SerializeField] private float fireRate = 1;
		[SerializeField] private Vector2 MaximalRecoil = Vector2.one;

		#endregion
	}
}
