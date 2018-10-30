using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : InventorySystem {

    public int SlotCatcher;

    public void OnMouseUp()
    {
        PickUp(gameObject);
    }
}
