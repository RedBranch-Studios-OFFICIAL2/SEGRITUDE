using UnityEngine;

namespace Segritude.InputManagement
{
	/// <summary>
	/// Reference point for all input
	/// </summary>
	public static class InputManager
	{
		#region Buttons

		/// <summary>
		/// Name for the button resposible for main interactions
		/// </summary>
		public const string InteractMain = "Interact Main";

		/// <summary>
		/// Name for the button resposible for main interactions
		/// </summary>
		public const string InteractLeft = "Interact Left";

		/// <summary>
		/// Name for the button resposible for main interactions
		/// </summary>
		public const string InteractRight = "Interact Right";

		#endregion Buttons

		#region Values

		/// <summary>
		/// Was the <see cref="InteractMain"/> just pressed
		/// </summary>
		public static bool IntaractMainDown { get { return Input.GetButtonDown(InteractMain); } }

		/// <summary>
		/// Was the <see cref="InteractRight"/> just pressed
		/// </summary>
		public static bool IntaractRightDown { get { return Input.GetButtonDown(InteractRight); } }

		/// <summary>
		/// Was the <see cref="InteractLeft"/> just pressed
		/// </summary>
		public static bool IntaractLeftDown { get { return Input.GetButtonDown(InteractLeft); } }

		/// <summary>
		/// Is the <see cref="InteractLeft"/> held down
		/// </summary>
		public static bool IntaractLeftHold { get { return Input.GetButton(InteractLeft); } }

		#endregion Values
	}
}