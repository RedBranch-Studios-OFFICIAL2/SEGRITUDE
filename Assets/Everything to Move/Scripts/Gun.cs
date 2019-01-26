using System.Collections;
using Segritude.Inventory;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Gun")]
public class Gun : Item
{
    #region PublicProperties

    public int Damage => damage;
    public int Range => range;

    public int MaxClip => maxClip;

    public float FireRate => fireRate;
    public bool Automatic => automatic;

    #endregion

    #region SerializedFields

    [SerializeField] private int damage = 10;
    [SerializeField] private int range = 150;
    
    [SerializeField] private int maxClip = 32;

    [SerializeField] private float fireRate;
    [SerializeField] private bool automatic;


    #endregion
}
