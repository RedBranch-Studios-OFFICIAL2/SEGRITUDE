using UnityEngine;

namespace Segritude.Interaction
{
	/// <summary>
	/// Base class for all interactable objects
	/// </summary>
	public abstract class InteractableBehaviour : MonoBehaviour, IInteractable
	{
		#region Public Property

		/// <summary>
		/// Does the interaction needs the player to hold the button
		/// </summary>
		public bool Hold => _Hold;

		/// <summary>
		/// How long does the player need to hold the button
		/// </summary>
		public float HoldTime => _HoldTime;

		/// <summary>
		/// What is the current interaction state (0-1)
		/// </summary>
		public float HoldState => _Hold ? _CurrentHoldTime / _HoldTime : (IsInteracting ? 1 : 0);

		/// <summary>
		/// Is the player currently interacting with the object
		/// </summary>
		public bool IsInteracting { get; private set; }

		/// <summary>
		/// Is the interaction automaticly repeating
		/// </summary>
		public bool Repeat => _Repeat;

		#endregion Public Property

		#region Serialized Fields

		/// <summary>
		/// Does the interaction needs the player to hold the button
		/// </summary>
		[SerializeField] private bool _Hold;

		/// <summary>
		/// How long does the player need to hold the button
		/// </summary>
		[SerializeField] private float _HoldTime = 1f;

		/// <summary>
		/// Is the interaction automaticly repeating
		/// </summary>
		[SerializeField] private bool _Repeat;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// For how long is the player interacting
		/// </summary>
		private float _CurrentHoldTime;

		/// <summary>
		/// Type of the current interaction. See <see cref="InteractionType"/>
		/// </summary>
		private InteractionType _Type;

		#endregion Private Fields

		#region Abstract Methods

		/// <summary>
		/// Called when the player succesfully interacts with the object
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		public abstract void OnInteract(InteractionType type);

		/// <summary>
		/// Called when player is trying to interact with the object
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		/// <returns>Is the interaction valid</returns>
		public abstract bool ValidateInteraction(InteractionType type);

		#endregion Abstract Methods

		#region Public Methods

		/// <summary>
		/// Starts the interaction
		/// </summary>
		/// <param name="type"></param>
		public void StartInteraction(InteractionType type)
		{
			IsInteracting = true;
			_CurrentHoldTime = 0;
			_Type = type;
		}

		/// <summary>
		/// Ends the current interaction of given type
		/// </summary>
		/// <param name="type">Type of the interaction. See <see cref="InteractionType"/></param>
		public void EndInteraction(InteractionType type)
		{
			if (type != _Type)
				return;
			IsInteracting = false;
		}

		#endregion Public Methods

		#region Initialization

		/// <summary>
		/// Called at the start of the scene
		/// </summary>
		private void Start()
		{
			gameObject.layer = LayerManager.InteractableLayer;
		}

		#endregion Initialization

		#region Unity Callbacks

		private void Update()
		{
			if (IsInteracting)
			{
				_CurrentHoldTime += Time.deltaTime;
				if (_CurrentHoldTime >= HoldTime || !Hold)
				{
					if (!Repeat)
						EndInteraction(_Type);
					_CurrentHoldTime = 0;
					OnInteract(_Type);
				}
			}
		}

		#endregion Unity Callbacks
	}
}