using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class skinSystem : MonoBehaviour {
   
   public Material GunColour;
   

    public void OnSkinPress(Button b)
    {
       Color colour= b.GetComponent<Image>().color;

        GunColour.color = colour;
    }
   
}
