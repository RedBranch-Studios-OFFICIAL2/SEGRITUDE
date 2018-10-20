using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : InventorySystem {

    public GameObject NewItem;

    public bool Insert = false;

    public void OnMouseDown()
    {
        PickUp(NewItem);
        
    }
}
