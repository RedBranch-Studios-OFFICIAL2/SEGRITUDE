using UnityEngine;

namespace Segritude
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
		public static bool InteractMainDown { get { return Input.GetButtonDown(InteractMain); } }

		/// <summary>
		/// Was the <see cref="InteractRight"/> just pressed
		/// </summary>
		public static bool InteractRightDown { get { return Input.GetButtonDown(InteractRight); } }

		/// <summary>
		/// Was the <see cref="InteractLeft"/> just pressed
		/// </summary>
		public static bool InteractLeftDown { get { return Input.GetButtonDown(InteractLeft); } }

		/// <summary>
		///  Was the <see cref="InteractMain"/> just released
		/// </summary>
		public static bool InteractMainRelease { get { return Input.GetButtonUp(InteractMain); } }

		/// <summary>
		///  Was the <see cref="InteractRight"/> just released
		/// </summary>
		public static bool InteractRightRelease { get { return Input.GetButtonUp(InteractRight); } }

		/// <summary>
		///  Was the <see cref="InteractLeft"/> just released
		/// </summary>
		public static bool InteractLeftRelease { get { return Input.GetButtonUp(InteractLeft); } }

		#endregion Values
	}
}