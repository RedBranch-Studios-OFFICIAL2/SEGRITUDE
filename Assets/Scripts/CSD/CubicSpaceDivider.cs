using System.Collections.Generic;
using UnityEngine;

namespace Segritude.CSD
{
	public class CubicSpaceDivider<T> where T : CubicSpacePoint<T>
	{
		public Vector3Int Position { get; set; }

		public List<T> Points { get; private set; } = new List<T>();
	}
}