using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

    public GameObject InventoryGui;
    public GameObject SlotParent;
    public GameObject HotBarParent;

    public Image[] Slots;
    public Image[] HotBars;
    public GameObject Cam;
    bool Open;

    void Start()
    {
        Open = false;
        Slots = SlotParent.GetComponentsInChildren<Image>();
        HotBars = HotBarParent.GetComponentsInChildren<Image>();
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
            gameObject.GetComponent<ChaController>().speed = 0;
            Cam.GetComponent<CamLook>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && Open == true)
        {
            Open = false;
            InventoryGui.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.GetComponent<ChaController>().speed = 4;
            Cam.GetComponent<CamLook>().enabled = true;
        }
    }
    // Method that will be called by items that can be picked up
    public void PickUp(GameObject item)
    {
        Debug.Log("You picked up "+ item.name);

        if(item.tag != "Weapon")
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].GetComponent<SlotScript>().StoredObject == null && Slots[i].tag != item.tag)
                {
                    // Sets slot to a random color to display its use and Changes the Tag to the object it is holding
                    Slots[i].tag = item.tag;
                    Slots[i].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                    // Stores the Object Collected
                    Slots[i].GetComponent<SlotScript>().StoredObject = item;
                    Slots[i].GetComponent<SlotScript>().Objects.Add(item);
                    Slots[i].GetComponent<SlotScript>().AmObjects = Slots[i].GetComponent<SlotScript>().AmObjects + 1;
                    Slots[i].GetComponent<SlotScript>().Amount.text = Slots[i].GetComponent<SlotScript>().AmObjects.ToString();
    

                    Debug.Log(Slots[i].GetComponent<SlotScript>().Objects[i]);

                    item.transform.parent = Slots[i].transform;
                    item.SetActive(false);

                    Debug.Log(i);
                    return;
                }
                else if (Slots[i].GetComponent<SlotScript>().StoredObject != null && Slots[i].tag == item.tag)
                {
                    // Sets slot to a random color to display its use and Changes the Tag to the object it is holding
                    Slots[i].tag = item.tag;
                    Slots[i].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                    // Stores the Object Collected
                    Slots[i].GetComponent<SlotScript>().StoredObject = item;
                    Slots[i].GetComponent<SlotScript>().Objects.Add(item);
                    Slots[i].GetComponent<SlotScript>().AmObjects = Slots[i].GetComponent<SlotScript>().AmObjects + 1;
                    Slots[i].GetComponent<SlotScript>().Amount.text = Slots[i].GetComponent<SlotScript>().AmObjects.ToString();

                    Debug.Log(Slots[i].GetComponent<SlotScript>().Objects[i]);

                    item.transform.parent = Slots[i].transform;
                    item.SetActive(false);

                    Debug.Log(i);
                    return;
                }
                else if (Slots[i].GetComponent<SlotScript>().StoredObject != null)
                {
                    i = i + 1;
                }
            }
        }
        else if(item.tag == "Weapon")
        {
            for(int i = 0; i < HotBars.Length; i++)
            {
                if(HotBars[i].GetComponent<SlotScript>().StoredObject == null && HotBars[i].tag != item.tag)
                {
                    // Identifies Hot Bar Slot for Picked up Object
                    HotBars[i].tag = item.tag;
                    HotBars[i].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                    // Sets the Stored Object to the Item picked up, and Also keeps track of how many objects are in that Stack
                    HotBars[i].GetComponent<SlotScript>().StoredObject = item;
                    HotBars[i].GetComponent<SlotScript>().Objects.Add(item);
                    HotBars[i].GetComponent<SlotScript>().AmObjects = HotBars[i].GetComponent<SlotScript>().AmObjects + 1;
                    HotBars[i].GetComponent<SlotScript>().Amount.text = HotBars[i].GetComponent<SlotScript>().AmObjects.ToString();

                    // Sets Object's parent as the Slot
                    item.transform.parent = HotBars[i].transform;
                    item.SetActive(false);
                    return;
                }
            }
        }
    }

}
