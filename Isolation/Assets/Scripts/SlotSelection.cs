using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelection : MonoBehaviour {

    public GameObject Slot;
    public GameObject Player;
    public GameObject Camera;

    public GameObject StoredObject;
    

    public void OnSlotSelect()
    {
        StoredObject = Slot.GetComponent<SlotScript>().StoredObject;

        Debug.Log(StoredObject);
        StoredObject.SetActive(true);
        StoredObject.transform.parent = null;
        StoredObject.transform.position = Player.transform.position + Camera.transform.forward * 2;

        Slot.GetComponent<SlotScript>().StoredObject = null;
        Slot.GetComponent<Image>().color = new Color32(0, 0, 0, 120);
    }
}
