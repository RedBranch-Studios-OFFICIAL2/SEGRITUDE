using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    public float health = 100;
    [Header("Hunger")]
    public int hunger = 100;
    public int minDecreasingHunger=2;   //lowest seconds for food 
    public int maxDecreasingHunger=10;
    [Header("Thirst")]
    public int thirst = 100;
    public int minDecreasingThirst=1;
    public int maxDecreasingThrist=9; // i know water should be more demanding but i will let you decide how demanding
    [Header("Stamina")]
    public int stamina = 100;
    public int StaminaDrains = 1;
    public int Delay_Stamina=7;//when it reach stamina drains faster
    public int Delay_StaminaStart;

    bool _stopped=true; //auxilary boolean

    

    public void Start()
    {
        Delay_StaminaStart = Delay_Stamina;
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
    public void Stamina() //you can call it with a bool at some time if you run too much or it is sunny or he is running throug water
    {
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
    }
    public void Stopped()
    {
        if (_stopped) //recover the delay
        {
            Delay_Stamina = Delay_StaminaStart;
            StaminaDrains = 1;
        }
    }
    #endregion
    #region Health&Thirst
    public void Hungry() //call it at some time 
    {
        int a = Random.Range(minDecreasingHunger, maxDecreasingHunger);
        hunger -= a;
    }
    public void Thristy() //call it at some time 
    {
        int b = Random.Range(minDecreasingThirst, maxDecreasingThrist);
        thirst -= b;
    }

    #endregion
}
