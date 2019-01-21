using System;
using UnityEngine;

namespace Segritude.Camera
{
	public class CameraController : GlobalBehaviour<CameraController>
	{
		#region Static Properties

		/// <summary>
		/// Is the camera currently usable
		/// </summary>
		public static bool UseCamera
		{
			get => useCamera;
			set
			{
				if (useCamera == value)
					return;
				useCamera = value;
				OnUseChange?.Invoke(useCamera);
			}
		}

		/// <summary>
		/// Event invoked when <see cref="UseCamera"/> changes
		/// </summary>
		public static event Action<bool> OnUseChange;

		#endregion Static Properties

		#region Static Fields

		/// <summary>
		/// Backend field for <see cref="UseCamera"/>
		/// </summary>
		private static bool useCamera;

		#endregion Static Fields

		#region Serialized Fields

		/// <summary>
		/// Sensitivity of the camera movement
		/// </summary>
		[SerializeField] private float sensitivity = 5.0f;

		/// <summary>
		/// How much smoothing should be applied
		/// </summary>
		[SerializeField] private float smoothing = 2.0f;

		/// <summary>
		/// Maximal angle that the player can look at
		/// </summary>
		[SerializeField] private float maxLookAngle = 60;

		/// <summary>
		/// Reference to the player object
		/// </summary>
		[SerializeField] private Transform player;

		#endregion Serialized Fields

		#region Private Fields

		/// <summary>
		/// Current rotation of the player
		/// </summary>
		private Vector2 rotation;

		/// <summary>
		/// Vector for calculating smothing
		/// </summary>
		private Vector2 smoothVector;

		#endregion Private Fields

		#region Unity Callbacks

		private void Awake()
		{
			base.Awake();
			OnUseChange += x =>
			{
				Cursor.lockState = x ? CursorLockMode.Locked : CursorLockMode.None;
				Cursor.visible = !x;
			};
		}

		private void Start()
		{
			UseCamera = true;
		}

		private void Update()
		{
			if (UseCamera)
				CalculateCameraRotation();
		}

		#endregion Unity Callbacks

		#region Private Methods

		/// <summary>
		/// Used for calculating camera rotation and smoothing
		/// </summary>
		private void CalculateCameraRotation()
		{
			var mousePositionDelta = new Vector2(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));

			mousePositionDelta.Scale(new Vector2(sensitivity * smoothing, sensitivity * smoothing));
			smoothVector.x = Mathf.Lerp(smoothVector.x, mousePositionDelta.x, 1f / smoothing);
			smoothVector.y = Mathf.Lerp(smoothVector.y, mousePositionDelta.y, 1f / smoothing);
			rotation += smoothVector;
			rotation.y = Mathf.Clamp(rotation.y, -maxLookAngle, maxLookAngle);

			transform.localRotation = Quaternion.Euler(rotation);
		}

		#endregion Private Methods
	}
}