using System;
using UnityEngine;
namespace Segritude.Camera
{
	public class CameraController : MonoBehaviour
	{
		#region Static Properties

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

		public static event Action<bool> OnUseChange;

		#endregion

		#region Static Fields

		private static bool useCamera;

		#endregion

		#region Serialized Fields

		[SerializeField] private float sensitivity = 5.0f;
		[SerializeField] private float smoothing = 2.0f;
		[SerializeField] private float maxLookAngle = 60;

		[SerializeField] private Transform player;

		#endregion

		#region Private Fields

		private Vector2 rotation;
		private Vector2 SmoothVector;

		#endregion



		#region Unity Callbacks

		private void Awake()
		{
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

		#endregion

		#region Private Methods

		private void CalculateCameraRotation()
		{
			var mousePositionDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

			mousePositionDelta = Vector2.Scale(mousePositionDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
			SmoothVector.x = Mathf.Lerp(SmoothVector.x, mousePositionDelta.x, 1f / smoothing);
			SmoothVector.y = Mathf.Lerp(SmoothVector.y, mousePositionDelta.y, 1f / smoothing);
			rotation += SmoothVector;
			rotation.y = Mathf.Clamp(rotation.y, -maxLookAngle, maxLookAngle);

			transform.localRotation = Quaternion.AngleAxis(-rotation.y, Vector3.right);
			player.localRotation = Quaternion.AngleAxis(rotation.x, player.transform.up);
		}

		#endregion

	}
}