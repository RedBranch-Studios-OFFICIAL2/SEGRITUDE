﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

    public GameObject InventoryGui;
    public GameObject SlotParent;

    public GameObject RightHand;

    public Image[] Slots;
    public int Slotx = 0;
    public GameObject Cam;
    bool Open;

    void Start()
    {
        Open = false;
        Slots = SlotParent.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Open and Closes the Inventory
        if (Input.GetKeyDown(KeyCode.E) && Open == false)
        {
            Open = true;
            InventoryGui.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cam.GetComponent<CamLook>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && Open == true)
        {
            Open = false;
            InventoryGui.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cam.GetComponent<CamLook>().enabled = true;
        }
    }
    // Method that will be called by items that can be picked up
    public void PickUp(GameObject item)
    {
        Debug.Log("You picked up "+ item.name);

        if(item.tag != "Weapon")
        {
            // Sets i to x, in order to keep track of the value of slots being inputted
            for (int i = Slotx; i < Slots.Length; i++)
            {
                Debug.Log(i);
                if (Slots[i].GetComponent<SlotScript>())
                {
                    // Sets slot to a random color to display its use
                    Slots[i].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                    // Adds the item picked up to the slot and keeps it there
                    if (Slots[i].GetComponent<SlotScript>().StoredObject == null)
                    {
                        Slots[i].GetComponent<SlotScript>().StoredObject = item;
                        item.transform.parent = Slots[i].transform;
                        item.SetActive(false);



                    }
                    break;
                }
            }
            Slotx = Slotx + 1;
        }
        else if(item.tag == "Weapon")
        {
            item.GetComponent<BoxCollider>().isTrigger = false;
            item.transform.parent = RightHand.transform;
            item.transform.position = new Vector3(-0.0020f, 0.00438f, 0.00108f);
        }
        
    }

}
