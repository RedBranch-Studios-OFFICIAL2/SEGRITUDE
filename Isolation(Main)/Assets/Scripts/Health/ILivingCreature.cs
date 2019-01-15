using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segritude.Health
{
	public interface ILivingCreature
	{
		int Health { get; }

		bool TakeDamage(int damage, IDamageSource source);
	}
}
