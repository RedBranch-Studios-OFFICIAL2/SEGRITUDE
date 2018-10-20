using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemPick : ScriptableObject {

    new public string name = "New Item";
    public float weight = 10f;
}
