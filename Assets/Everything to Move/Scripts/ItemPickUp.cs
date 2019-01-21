using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : New_Inventory {

    public GameObject Item;
    public float Weight = 10;
    public Sprite Icon;

    public void OnMouseDown()
    {
        Item = gameObject;
        PickUp(Item, Weight,Icon);
    }
}
