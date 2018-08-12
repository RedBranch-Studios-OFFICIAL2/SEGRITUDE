using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectableObjects : MonoBehaviour
{
    public double PlayerWeight = 0;
    public Text WeightText;
    public Text canPick;
    bool Pick = false;
    bool Touch = false;

    public int Weights(GameObject gb)
    {

        int woodWeight = 10;
        int stoneWeight = 15;
        int weightToReturn;
        string gbTag = gb.transform.parent.name;
        switch (gbTag)
        {
            case "wood":
                weightToReturn = woodWeight;
                break;

            case "stone":
                weightToReturn = stoneWeight;
                break;

            default:
                weightToReturn = 0;
                break;

        }
        return (weightToReturn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Touch = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Touch = true;
            canPick.gameObject.SetActive(true);
            if (Pick == true)
            {
                int WeightToAdd = Weights(collision.gameObject);
                PlayerWeight += WeightToAdd;


                Destroy(collision.gameObject);
                Pick = false;
                canPick.gameObject.SetActive(false);
                Touch = false;
            }

        }


    }
    private void OnCollisionExit(Collision collision)
    {
        canPick.gameObject.SetActive(false);
        Pick = false;
        Touch = false;
    }
    private void Update()
    {
        WeightText.text = "Weight = " + PlayerWeight.ToString();

        if (Input.GetKeyDown("e") && Touch == true)
        {
            Pick = true;
        }

    }

}