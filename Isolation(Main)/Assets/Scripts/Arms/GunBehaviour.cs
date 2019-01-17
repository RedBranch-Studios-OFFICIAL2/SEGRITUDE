using UnityEngine;

namespace Segritude.Arms
{
	public class GunBehaviour : MonoBehaviour
	{
		#region Serialized Fields

		[SerializeField] private Gun gun;

		#endregion Serialized Fields

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
				Shoot();
		}

		private void Shoot()
		{
			//SOME SCHOOTING LOGIC
			//YOUR JOB
		}
	}
}