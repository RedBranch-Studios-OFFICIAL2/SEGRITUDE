using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New_SlotScript : MonoBehaviour {

    public GameObject StoredObject;
    public GameObject Options;
    public GameObject Icon;
    public Text Display;
    private bool OptionsEnabled = false;

    public float Weight;
    public float Current = 0;

    public int MaxStack = 16;
    public List<GameObject> CollectedItems;

    public GameObject Player;

    public void OnSelection()
    {
        OptionsEnabled = !OptionsEnabled;

        if(OptionsEnabled == true)
        {
            Options.SetActive(true);
        }
        else
        {
            Options.SetActive(false);
        }
    }

    public void Drop()
    {
        //Instantiates an Object
        GameObject Object = Instantiate(StoredObject, Player.transform.position + Player.transform.forward * 2, Player.transform.rotation);
        Object.name = StoredObject.name;
        //Object.SetActive(true);

        //Destroys Original Object
        CollectedItems.Remove(StoredObject);
        Destroy(StoredObject);
        if (CollectedItems.Count > 0)
        {
            StoredObject = CollectedItems[0];
        }
        else if (CollectedItems.Count == 0)
        {
            StoredObject = null;

            //Slot Image Display
            gameObject.GetComponent<New_SlotScript>().Icon.GetComponent<Image>().sprite = null;
            gameObject.GetComponent<New_SlotScript>().Icon.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }

        //Disables the Options
        OptionsEnabled = !OptionsEnabled;
        Options.SetActive(OptionsEnabled);
    }

    public void Use()
    {
        if (StoredObject.tag == "Food")
        {
            //Increases Food
            Player.GetComponent<Playeratt>().Hunger = Player.GetComponent<Playeratt>().Hunger + 10;

            //Removes Item from Slot
            CollectedItems.Remove(StoredObject);
            Destroy(StoredObject);
            if (CollectedItems.Count > 0)
            {
                StoredObject = CollectedItems[0];
            }
            else if (CollectedItems.Count == 0)
            {
                StoredObject = null;

                //Slot Image Display
                gameObject.GetComponent<New_SlotScript>().Icon.GetComponent<Image>().sprite = null;
                gameObject.GetComponent<New_SlotScript>().Icon.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }

            //Changes Number of Stored Objects
            gameObject.GetComponent<New_SlotScript>().Current = gameObject.GetComponent<New_SlotScript>().Current - 1;
            gameObject.GetComponent<New_SlotScript>().Display.text = gameObject.GetComponent<New_SlotScript>().Current.ToString();

            //Disables the Options
            OptionsEnabled = !OptionsEnabled;
            Options.SetActive(OptionsEnabled);

            //Print Confirmation
            Debug.Log("You've Consumed Food.");
        }
        else if (StoredObject.tag == "Water")
        {
            //Increases Water
            Player.GetComponent<Playeratt>().Thirst = Player.GetComponent<Playeratt>().Thirst + 10;

            //Removes Item from Slot
            CollectedItems.Remove(StoredObject);
            Destroy(StoredObject);
            if (CollectedItems.Count > 0)
            {
                StoredObject = CollectedItems[0];
            }
            else if (CollectedItems.Count == 0)
            {
                StoredObject = null;

                //Slot Image Display
                gameObject.GetComponent<New_SlotScript>().Icon.GetComponent<Image>().sprite = null;
                gameObject.GetComponent<New_SlotScript>().Icon.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }

            //Changes Number of Stored Objects
            gameObject.GetComponent<New_SlotScript>().Current = gameObject.GetComponent<New_SlotScript>().Current - 1;
            gameObject.GetComponent<New_SlotScript>().Display.text = gameObject.GetComponent<New_SlotScript>().Current.ToString();

            //Disables the Options
            OptionsEnabled = !OptionsEnabled;
            Options.SetActive(OptionsEnabled);

            //Print Confirmation
            Debug.Log("You've Consumed Food.");
        }
    }
    
}
