using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelection : InventorySystem {

    public GameObject StoredObject;
    public GameObject Player;

    public Interactable[] Items;

    public bool Active = false;

    public void OnSlotSelect()
    {
        if (gameObject.transform.parent.GetComponent<SlotScript>().StoredObject != null)
        {
            Items = gameObject.transform.parent.GetComponentsInChildren<Interactable>();

            // Removes an Item from the slot
            StoredObject = gameObject.transform.parent.GetComponent<SlotScript>().StoredObject;
            gameObject.transform.parent.GetComponent<SlotScript>().AmObjects = gameObject.transform.parent.GetComponent<SlotScript>().AmObjects - 1;
            gameObject.transform.parent.GetComponent<SlotScript>().Amount.text = gameObject.transform.parent.GetComponent<SlotScript>().AmObjects.ToString();

             // Sets next Item in slot
            gameObject.transform.parent.GetComponent<SlotScript>().Objects.Remove(StoredObject);

            //gameObject.transform.parent.GetComponent<SlotScript>().StoredObject = gameObject.transform.parent.GetComponent<SlotScript>().Objects. ;
            StoredObject = gameObject.transform.parent.GetComponent<SlotScript>().StoredObject;

            Debug.Log("Slot Selected");
            // Places the Removed Item in front of the character
            StoredObject.transform.parent = null;
            StoredObject.SetActive(true);
            StoredObject.transform.position = Player.transform.position + Player.transform.forward;
            StoredObject = null;

            gameObject.transform.parent.GetComponent<SlotScript>().StoredObject = null;

            if (gameObject.transform.parent.GetComponent<SlotScript>().AmObjects > 0)
            {
                return;
            }
            else if (gameObject.transform.parent.GetComponent<SlotScript>().AmObjects == 0)
            {
                gameObject.transform.parent.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
            }
        }
        else if (gameObject.transform.parent.GetComponent<SlotScript>().StoredObject == null)
        {
            Debug.Log("Nothing Found!");
            //Active = true;
            return;
        }
    }

    /*public void Update()
    {
        if(Active == true)
        {
            Debug.Log("Slot Changing!");
            gameObject.transform.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Active = false;
        }
    }*/
}
