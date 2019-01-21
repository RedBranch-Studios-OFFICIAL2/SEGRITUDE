using System;

namespace Segritude.Interaction
{
	/// <summary>
	/// Types of interaction
	/// </summary>
	[Flags]
	public enum InteractionType
	{
		Left = 1,
		Right = 2,
		Main = 4
	}
}