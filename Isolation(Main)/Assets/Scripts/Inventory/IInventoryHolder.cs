using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segritude.Inventory
{
	public interface IInventoryHolder
	{
		Inventory Inventory { get; }
	}
}
