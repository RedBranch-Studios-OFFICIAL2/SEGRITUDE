using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		/// Name for the button resposible for interactions
		/// </summary>
		public const string Interact = "Interact";

		#endregion

		#region Values

		/// <summary>
		/// Was the <see cref="Interact"/> just pressed
		/// </summary>
		public static bool IntaractDown { get { return Input.GetButtonDown(Interact); } }

		#endregion


	}
}
