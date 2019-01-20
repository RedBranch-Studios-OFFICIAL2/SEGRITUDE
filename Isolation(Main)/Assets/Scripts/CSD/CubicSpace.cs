using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Segritude.CSD
{
	public class CubicSpace<T> : IEnumerable<KeyValuePair<Vector3, CubicSpaceDivider<T>>> where T : CubicSpacePoint<T>
	{
		public static CubicSpace<T> Instance { get; private set; }

		public float DividerSize { get; private set; }

		private Dictionary<Vector3, CubicSpaceDivider<T>> dividers;

		public IEnumerable<CubicSpaceDivider<T>> GetAdjentDividers(Vector3Int position)
		{
			var adjent = new List<CubicSpaceDivider<T>>();
			for (int x = -1; x <= 1; x++)
				for (int z = -1; z <= 1; z++)
					for (int y = -1; y <= 1; y++)
						adjent.Add(dividers[position += new Vector3Int(x, y, z)]);
			return adjent.Where(x => !(x is null));
		}

		public IEnumerator<KeyValuePair<Vector3, CubicSpaceDivider<T>>> GetEnumerator() => dividers.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => dividers.GetEnumerator();

		public CubicSpace(float dividerSize)
		{
			Instance = this;
			DividerSize = dividerSize;
		}
	}
}