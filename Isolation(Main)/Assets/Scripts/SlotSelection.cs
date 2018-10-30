using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelection : InventorySystem {

    public GameObject StoredObject;
    public GameObject Player;

    public void OnSlotSelect()
    {
        StoredObject = gameObject.transform.parent.GetComponent<SlotScript>().StoredObject;
        Debug.Log("Slot Selected");

        StoredObject.transform.parent = null;
        StoredObject.SetActive(true);
        StoredObject.transform.position = Player.transform.position + Player.transform.forward;
        StoredObject = null;

        gameObject.transform.parent.GetComponent<SlotScript>().StoredObject = null;

        gameObject.transform.parent.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
    }
}
