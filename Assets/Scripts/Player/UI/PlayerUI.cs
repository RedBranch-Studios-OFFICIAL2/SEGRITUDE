using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Segritude.Player.UI
{
	public class PlayerUI : MonoBehaviour
	{
		[SerializeField] private Slider health;
		[SerializeField] private Slider hunger;
		[SerializeField] private Slider thirst;
		[SerializeField] private Slider stamina;

		public void UpdateUI()
		{
			health.value = PlayerBehaviour.Instance.Health;
		}
	}
}
