using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSelection : MonoBehaviour {

    public GameObject Slot;

    public GameObject StoredObject;

    public void OnSlotSelect()
    {
        StoredObject = Slot.GetComponent<SlotScript>().StoredObject;

        Debug.Log(StoredObject);
    }
}
