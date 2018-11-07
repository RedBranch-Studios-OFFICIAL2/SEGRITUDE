using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Farming")]
    public Camera cam;
    public float range;
    [Header("Health")]
    public float health = 100;
    [Header("Hunger")]
    public int hunger = 100;
    public int minDecreasingHunger =0;   //lowest seconds for food 
    public int maxDecreasingHunger = 10;
    float Probably = 1000; //it gets low and low and when is very low means that is very probably that you will get hungry but you can get hungry before it gets that low
    float StartProbably;
    [Header("Thirst")]
    public int thirst = 100;
    public int minDecreasingThirst = 0;
    public int maxDecreasingThrist = 9; // i know water should be more demanding but i will let you decide how demanding
    [Header("Stamina")]
    public int stamina = 100;
    public int StaminaDrains = 1;
    public int Delay_Stamina = 7;//when it reach stamina drains faster
    int Delay_StaminaStart;

    [Header("UI")]
    public Slider hungerSlider;
    public TextMeshProUGUI hungerText;
    public Slider thirstSlider;
    public TextMeshProUGUI thirstText;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    Destroyable destroyable;

    bool _stopped = true; //auxilary boolean

    private void Update()
    {
        if (Mathf.Ceil(Random.Range(0, Probably))==Mathf.Ceil(Probably)||(Probably<=0))
        {
            GetHungryAndThirsty();
        }
        Probably -= .1f;
       
        if (Input.GetMouseButtonDown(0))
        {
            Farm();
        }
    }
    
    
    void GetHungryAndThirsty() 
    {
        Probably = StartProbably;
        Hungry();
        Thirsty();

    }
    public void Start()
    {
        Delay_StaminaStart = Delay_Stamina;
        StartProbably = Probably;
    }

    #region Health
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //some animation
    }
    #endregion
    #region Stamina
    public void Stamina(int Drain=1) //you can call it with a bool at some time if you run too much or it is sunny or he is running throug water
    {
        StaminaDrains = Drain;
        stamina-=StaminaDrains;
        _stopped = false;
        if (!_stopped)  //if you run too much withou stopping stamina drains faster
        {
            Delay_Stamina--;
        }
        if (Delay_Stamina <= 0)
        {
            StaminaDrains++;
        }
        if (_stopped) //recover the delay
        {
            Delay_Stamina = Delay_StaminaStart;
            StaminaDrains = 1;
            stamina++;
        }
    }
   
    #endregion
    #region Health&Thirst
    public void Hungry() //call it at some time 
    {
        int a = Random.Range(minDecreasingHunger, maxDecreasingHunger);
        hunger -= a;
    }
    public void Thirsty() //call it at some time 
    {
        int b = Random.Range(minDecreasingThirst, maxDecreasingThrist);
        thirst -= b;
    }

    #endregion
    #region Farming System
    RaycastHit hit;
    public void Farm()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, range))
        {
            if (hit.collider.tag == "Destroyable")
            {
                destroyable = hit.collider.GetComponent<Destroyable>();
                destroyable.Damage(2, this);//the first argument can be changed with a variable of the tool you are using etc
                Debug.Log("Hit something");
            }
        }
    }
    #endregion
}
