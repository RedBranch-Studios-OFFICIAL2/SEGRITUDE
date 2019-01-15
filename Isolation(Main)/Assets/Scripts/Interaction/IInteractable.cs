using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segritude.Interaction
{
	public interface IInteractable
	{
		void StartInteraction(InteractionType type);
		void EndInteraction(InteractionType type);
		bool ValidateInteraction(InteractionType type);
	}
}
