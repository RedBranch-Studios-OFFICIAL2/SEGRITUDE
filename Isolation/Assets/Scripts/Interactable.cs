using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : InventorySystem {

    public GameObject NewItem;
    
    public void OnMouseDown()
    {
        PickUp(NewItem);
    }
}
