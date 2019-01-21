using System.Collections;
using System.Collections.Generic;
using Segritude.Camera;
using Segritude.Health;
using Segritude.Interaction;
using Segritude.Inventory.Items;
using UnityEngine;

namespace Segritude.Arms
{
	public class GunBehaviour : InteractableItemBehaviour, IDamageSource
	{
		public Gun Gun => Item as Gun;

		[SerializeField] private GameObject barrel;

		private int clip;
		private bool isReloading;


		protected override InteractionType InteractionTypes => InteractionType.Left;
		protected override float InteractionTime => Gun.FireRate;
		protected override bool ImidiateInteraction => true;
		protected override bool RepeatInteraction => Gun.Automatic;

		// Update is called once per frame
		private new void Update()
		{
			base.Update();
			if (Input.GetKeyDown(KeyCode.R) && clip < Gun.MaxClip)
			{
				if (clip < Gun.MaxClip)
				{
					Reload();
				}
			}

		}

		void Reload() => clip = Gun.MaxClip;

		void Shoot()
		{
			var forward = CameraController.Instance.transform.TransformDirection(Vector3.forward);
			Debug.DrawRay(barrel.transform.position, forward, Color.red);
			if (Physics.Raycast(barrel.transform.position, CameraController.Instance.transform.forward, out var hit, Gun.Range))
			{
				hit.transform.GetComponent<ILivingCreature>()?.TakeDamage(Gun.Damage, this);
			}

		}

		public override void OnInteract(InteractionType type) => Shoot();

		public override void OnSelectItem()
		{
			base.OnSelectItem();
			clip = Gun.MaxClip;
		}

		public override bool ValidateInteraction(InteractionType type) => base.ValidateInteraction(type) && !isReloading;
	}
}