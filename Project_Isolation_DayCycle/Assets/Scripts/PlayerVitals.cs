using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerVitals : MonoBehaviour //this script is very wrong
{
    public Image healthImage;
    public TextMeshProUGUI healthText;
    public  float  maxHealth=100;
    public float health; 
    public float healthFallRate;

    public Image thirstImage;
    public TextMeshProUGUI thirstText;
    public float maxThirst=100;
    public float thirst;
    public float thirstFallRate;

    public Image hungerImage;
    public TextMeshProUGUI hungerText;
    public float maxHunger=100;
    public float hunger;
    public float hungerFallRate;

    void Start()
    {
       
        health = maxHealth;

        thirst = maxThirst;

        hunger = maxHunger;
    }

    void FixedUpdate()
    {
        //HEALTH CONTROL SECTION
        if (hunger <= 0 && (thirst <= 0))
        {
            health -= (Time.deltaTime / healthFallRate) * 2;
        }

        else if (hunger <= 0 || thirst <= 0)
        {
            health -= Time.deltaTime / healthFallRate;
        }

        if (health <= 0)
        {
            CharacterDeath();
        }

        //HUNGER CONTROL SECTION
        if (hunger >= 0)
        {
            hunger -= Time.deltaTime / hungerFallRate;
        }

        else if (hunger <= 0)
        {
            hunger = 0;
        }

        else if (hunger >= maxHunger)
        {
            hunger = maxHunger;
        }

        //THIRST CONTROL SECTION
        if (thirst >= 0)
        {
            thirst -= Time.deltaTime / thirstFallRate;
        }

        else if (thirst <= 0)
        {
            thirst = 0;
        }

        else if (thirst >= maxThirst)
        {
            thirst = maxThirst;
        }
        healthImage.fillAmount = (health / maxHealth);
        healthText.text = ("Health=" + ((int)(health / maxHealth * 100))+("%")).ToString();

        hungerImage.fillAmount = (hunger / maxHunger);
        hungerText.text = ("Health=" + ((int)(hunger / maxHunger * 100))+("%")).ToString();

        thirstImage.fillAmount = (thirst / maxThirst);
        thirstText.text = ("Health=" + ((int)(thirst / maxThirst * 100))+("%")).ToString();

    }

    void CharacterDeath()
    {
            //DEATH
    }
}
