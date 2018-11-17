using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public Item item;
    float hitPoints = 10f;
    public void Damage(float dmg, Player player)
    {
        Debug.Log("give the player item " + item.nameItem);
        hitPoints -= dmg;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
