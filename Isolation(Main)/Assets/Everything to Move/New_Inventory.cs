using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New_Inventory : MonoBehaviour
{
	private bool inventoryEnabled;

	private bool inventoryOpen
	{
		get
		{
			return inventoryEnabled;
		}
		set
		{
			inventoryEnabled = value;
			if (inventoryEnabled == true)
			{
				Cursor.lockState = CursorLockMode.None;
				Camera.GetComponent<CamLook>().enabled = false;
				inventory.SetActive(true);
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
				Camera.GetComponent<CamLook>().enabled = true;
				inventory.SetActive(false);
			}
		}
	}


	public GameObject inventory;

	public Text CurrentWeight;
	public static float CWeight;
	public Text MaxWeight;
	public static float MWeight;

	public GameObject Camera;

	private int allSlots;
	private int enabledSlots;
	private GameObject[] slot;

	public GameObject SlotHolder;

	void Start()
	{
		MWeight = 100f;
		MaxWeight.text = MWeight.ToString();

		CWeight = 0;
		CurrentWeight.text = CWeight.ToString();

		allSlots = 36;
		slot = new GameObject[allSlots];

		for (int i = 0; i < allSlots; i++)
		{
			slot[i] = SlotHolder.transform.GetChild(i).gameObject;
		}

		inventoryOpen = false;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
			inventoryOpen ^= true;
	}

	public void PickUp(GameObject Item, float Weight, Sprite Icon)
	{
		Debug.Log(Item.name + " " + Weight);

		for (int i = 0; i < slot.Length; i++)
		{
			if (slot[i].GetComponent<New_SlotScript>().StoredObject == null && slot[i].tag != Item.tag && CWeight < MWeight)
			{
				//Adds the Amount weighted of the object
				CWeight = CWeight + Weight;
				CurrentWeight.text = CWeight.ToString();

				// Sets the Stored Object in the slot as the Item Picked up.
				slot[i].GetComponent<New_SlotScript>().StoredObject = Item;
				slot[i].GetComponent<New_SlotScript>().Weight = slot[i].GetComponent<New_SlotScript>().Weight + Weight;
				slot[i].tag = Item.tag;

				// Stores Object
				Item.transform.parent = slot[i].transform;
				Item.SetActive(false);

				// Adds Icon of Object Picked up.
				slot[i].GetComponent<New_SlotScript>().Icon.GetComponent<Image>().sprite = Icon;
				slot[i].GetComponent<New_SlotScript>().Icon.GetComponent<Image>().color = new Color(255, 255, 255, 255);

				// Add to List of Objects for Stacking
				slot[i].GetComponent<New_SlotScript>().CollectedItems.Add(Item);
				slot[i].GetComponent<New_SlotScript>().Current = slot[i].GetComponent<New_SlotScript>().Current + 1;
				slot[i].GetComponent<New_SlotScript>().Display.text = slot[i].GetComponent<New_SlotScript>().Current.ToString();

				return;
			}
			else if (slot[i].GetComponent<New_SlotScript>().StoredObject != null && slot[i].tag == Item.tag && CWeight < MWeight && Item.tag != "Weapon")
			{
				//Adds the Amount weighted of the object
				CWeight = CWeight + Weight;
				CurrentWeight.text = CWeight.ToString();

				// Sets the Next Stored Objects in the Stack as the Item Picked up.
				slot[i].GetComponent<New_SlotScript>().StoredObject = Item;
				slot[i].GetComponent<New_SlotScript>().Weight = slot[i].GetComponent<New_SlotScript>().Weight + Weight;

				// Stores Object
				Item.transform.parent = slot[i].transform;
				Item.SetActive(false);

				// Adds Icon of Object Picked up.
				slot[i].GetComponent<New_SlotScript>().Icon.GetComponent<Image>().sprite = Icon;
				slot[i].GetComponent<New_SlotScript>().Icon.GetComponent<Image>().color = new Color(255, 255, 255, 255);

				// Add to List of Objects for Stacking
				slot[i].GetComponent<New_SlotScript>().CollectedItems.Add(Item);
				slot[i].GetComponent<New_SlotScript>().Current = slot[i].GetComponent<New_SlotScript>().Current + 1;
				slot[i].GetComponent<New_SlotScript>().Display.text = slot[i].GetComponent<New_SlotScript>().Current.ToString();

				return;
			}


		}
	}
}
