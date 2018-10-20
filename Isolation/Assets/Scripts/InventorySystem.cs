using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

    public GameObject InventoryGui;
    public GameObject SlotParent;

    public Image[] Slots;
    public List<GameObject> Items = new List<GameObject>();
    public int x = 0;
    public int Capacity = 35;

    public bool Additem;

    public GameObject Cam;

    bool Open;

    void Start()
    {

        Open = false;
        Additem = false;

        Slots = SlotParent.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("You have picked up " + item);

        for(int i = x;  i < Slots.Length; i++)
        {
            if (Slots[i].GetComponent<SlotScript>())
            {
                Debug.Log(i);
                x = x + 1;
                Debug.Log(Slots[i]);
                Slots[i].GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                Items.Add(item);
                if (Slots[i].GetComponent<SlotScript>().StoredObject == null)
                {
                    Slots[i].GetComponent<SlotScript>().StoredObject = item;
                    item.transform.parent = Slots[i].transform;
                }
                
                break;
            }
        }

    }

}
