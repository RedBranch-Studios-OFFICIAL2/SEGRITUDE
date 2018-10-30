using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playeratt : MonoBehaviour {

    //Player Att:
    public float Healt;
    public float healtOverTime;

    public float Hunger;
    public float hungerOverTime;


    public float Thirst;
    public float thirstOverTime;

    public float Stamina;
    public float staminaOverTime;

    public Slider HealtBar;
    public Slider HungerBar;
    public Slider ThirstBar;
    public Slider StaminaBar;

    public float minAmount = 2f; //min ammount of hunger,thrist before player start to lose healt
    public float sprintSpeed = 5f; //rigbody speed if it higher then this stamina will reduce

	void Start () {
        HealtBar.maxValue = Healt;
        StaminaBar.maxValue = Stamina;
        HungerBar.maxValue = Hunger;
        ThirstBar.maxValue = Thirst;
		
	}
	
	
	void Update () {
        CalculateValues();
		
	}

    private void CalculateValues()
    {
        Hunger -= hungerOverTime * Time.deltaTime;
        Thirst -= thirstOverTime * Time.deltaTime;

        if (Hunger <= minAmount || Thirst <= minAmount)
        {
            Healt -= healtOverTime * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        { 
            Stamina -= 10 * Time.deltaTime;
            Hunger -= 0.1f * Time.deltaTime;
            Thirst -= 0.1f * Time.deltaTime;
        }
        else
        {
            Stamina += 5f * Time.deltaTime;
        }

        if(Healt <= 0)
        {
            print("Dead :(");
        }

        updateUI();

}
    private void updateUI()
    {
        Healt = Mathf.Clamp(Healt, 0f, 100f);
        Thirst = Mathf.Clamp(Thirst, 0f, 100f);
        Hunger = Mathf.Clamp(Hunger, 0f, 100f);
        Stamina = Mathf.Clamp(Stamina, 0f, 200f);

        HealtBar.value = Healt;
        HungerBar.value = Hunger;
        ThirstBar.value = Thirst;
        StaminaBar.value = Stamina;
        
    }

    void OnTriggerEnter(Collider other) //For item devloper please change tag of item before u make it here i will program for evryitem do back different ammount of att.
    {
        if(other.tag == "Food")
        {
            Hunger = Hunger + 50;
            Destroy(other.gameObject);
        }

        if (other.tag == "Water")
        {
            Thirst = Thirst + 50;
            Destroy(other.gameObject);
        }

        if (other.tag == "staminapot")
        {
            Stamina = Stamina + 25f;
            Destroy(other.gameObject);
        }

        if (other.tag == "HealtPot")
        {
            Healt = Healt + 10;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }
}
