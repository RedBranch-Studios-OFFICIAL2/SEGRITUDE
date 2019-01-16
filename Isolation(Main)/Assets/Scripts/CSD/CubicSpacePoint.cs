using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Segritude.CSD
{
	public abstract class CubicSpacePoint<T> where T : CubicSpacePoint<T>
	{
		public abstract Vector3 Position { get; }

		public CubicSpaceDivider<T> Divider { get; set; }

		public IEnumerable<T> NearbyPoints => CubicSpace<T>.Instance.GetAdjentDividers(Divider.Position).SelectMany(x => x.Points).Where(x => !x.Equals(this));

		public void AddToSpace()
		{
			var position = Position / CubicSpace<T>.Instance.DividerSize;
		}
	}
}