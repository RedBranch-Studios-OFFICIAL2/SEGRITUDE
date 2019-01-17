using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Gun")]
public class GunData : MonoBehaviour
{
    #region Public Property

    public float Damage => damage;
    public float Range => range;

    /*public float clip = 30f;
    public float max = 30f;*/

    #endregion

    #region
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 150f;

    #endregion
}
}
