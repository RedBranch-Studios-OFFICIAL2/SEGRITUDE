using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotSlotScript : InventorySystem {

    public GameObject StoredObject;
    public GameObject Player;

    public Interactable[] Items;

    public bool Active = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnSlotSelect();
        }
    }

    public void OnSlotSelect()
    {
        if (gameObject.transform.parent.GetComponent<SlotScript>().StoredObject != null)
        {
            Items = gameObject.transform.parent.GetComponentsInChildren<Interactable>();

            // Removes an Item from the slot
            StoredObject = gameObject.GetComponent<SlotScript>().StoredObject;
            gameObject.GetComponent<SlotScript>().AmObjects = gameObject.GetComponent<SlotScript>().AmObjects - 1;
            gameObject.GetComponent<SlotScript>().Amount.text = gameObject.GetComponent<SlotScript>().AmObjects.ToString();

            // Sets next Item in slot
            gameObject.GetComponent<SlotScript>().Objects.Remove(StoredObject);

            //gameObject.transform.parent.GetComponent<SlotScript>().StoredObject = gameObject.transform.parent.GetComponent<SlotScript>().Objects. ;
            StoredObject = gameObject.GetComponent<SlotScript>().StoredObject;

            Debug.Log("Slot Selected");
            // Places the Removed Item in front of the character
            StoredObject.transform.parent = null;
            StoredObject.SetActive(true);
            StoredObject.transform.position = Player.transform.position + Player.transform.forward;
            StoredObject = null;

            gameObject.GetComponent<SlotScript>().StoredObject = null;

            if (gameObject.GetComponent<SlotScript>().AmObjects > 0)
            {
                return;
            }
            else if (gameObject.GetComponent<SlotScript>().AmObjects == 0)
            {
                gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
            }
        }
        else if (gameObject.GetComponent<SlotScript>().StoredObject == null)
        {
            Debug.Log("Nothing Found!");
            //Active = true;
            return;
        }
    }
}
