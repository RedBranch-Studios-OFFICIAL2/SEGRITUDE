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

		/// <summary>
		/// Name of the ith slot button
		/// </summary>
		/// <param name="i">Index of the button</param>
		/// <returns>Name of the button</returns>
		public static string Slot(int i) => $"Slot {i}";

		/// <summary>
		/// Name of the inventory button
		/// </summary>
		public const string Inventory = "Inventory";

		/// <summary>
		/// Name of the crouch button
		/// </summary>
		public const string Crouch = "Crouch";

		/// <summary>
		/// Name of the jump button
		/// </summary>
		public const string Jump = "Jump";

		/// <summary>
		/// Name of the run button
		/// </summary>
		public const string Run = "Run";

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

		/// <summary>
		/// Was the <see cref="Slot(int)"/> just pressed
		/// </summary>
		/// <param name="i">Index of the slot</param>
		/// <returns>Was the slot button pressed</returns>
		public static bool SlotDown(int i) => Input.GetButtonDown(Slot(i));

		/// <summary>
		/// Was the <see cref="Slot(int)"/> just released
		/// </summary>
		/// <param name="i">Index of the slot</param>
		/// <returns>Was the slot button released</returns>
		public static bool SlotRelease(int i) => Input.GetButtonUp(Slot(i));

		/// <summary>
		/// Was the Inventory just presed
		/// </summary>
		public static bool InventoryDown => Input.GetButtonDown(Inventory);

		/// <summary>
		/// Was the <see cref="Crouch"/> just pressed
		/// </summary>
		public static bool CrouchDown => Input.GetButtonDown(Crouch);

		/// <summary>
		/// Is the <see cref="Jump"/> held down
		/// </summary>
		public static bool JumpHeld => Input.GetButton(Jump);

		/// <summary>
		/// Is the <see cref="Run"/> held down
		/// </summary>
		public static bool RunHeld => Input.GetButton(Run);

		#endregion Values
	}
}