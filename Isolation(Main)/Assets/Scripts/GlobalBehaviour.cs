using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Segritude
{
	/// <summary>
	/// Give access to this instace of the class to everyone
	/// </summary>
	public abstract class GlobalBehaviour<T> : MonoBehaviour where T : GlobalBehaviour<T>
	{
		#region Public Properties

		/// <summary>
		/// Globally accessable instance of the class
		/// </summary>
		public static T Instance
		{
			get; private set;
		}

		#endregion

		#region Initialization

		/// <summary>
		/// Called at the beggining of the scene
		/// </summary>
		private void Start()
		{
			Instance = (T)this;
		}

		#endregion

	}
}
