using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playeratt : MonoBehaviour {
    
    //Player Att:
    public float Health;
    public float healthOverTime;

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

    public float minAmount = 3f; //min ammount of hunger,thrist before player start to lose healt
    public float sprintSpeed = 5f; //rigbody speed if it higher then this stamina will reduce

	void Start () {
        Health = 100;
        healthOverTime = 5;
        HealtBar.maxValue = Health;

        Stamina = 100;
        StaminaBar.maxValue = Stamina;

        Hunger = 100;
        hungerOverTime = 0;
        HungerBar.maxValue = Hunger;

        Thirst = 100;
        thirstOverTime = 0;
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
            Health -= healthOverTime * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        { 
            Stamina -= 10 * Time.deltaTime;
            Hunger -= 0.1f * Time.deltaTime;
            Thirst -= 0.1f * Time.deltaTime;
        }
        else if(Stamina < 100)
        {
            Stamina += 5f * Time.deltaTime;
        }

        if(Health <= 0)
        {
            print("Dead :(");
            Cursor.lockState = CursorLockMode.None;
    }

        updateUI();

        }
    private void updateUI()
    {
        Health = Mathf.Clamp(Health, 0f, 100f);
        Thirst = Mathf.Clamp(Thirst, 0f, 100f);
        Hunger = Mathf.Clamp(Hunger, 0f, 100f);
        Stamina = Mathf.Clamp(Stamina, 0f, 200f);

        HealtBar.value = Health;
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

        if (other.tag == "HealthPot")
        {
            Health = Health + 10;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }
}
