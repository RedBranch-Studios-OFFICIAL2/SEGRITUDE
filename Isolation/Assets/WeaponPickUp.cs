using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : InventorySystem {

    public GameObject Weapon;
    
    public void OnMouseDown()
    {
        Debug.Log("Picking up Weapon");
        PickUp(Weapon);        
    }
}
