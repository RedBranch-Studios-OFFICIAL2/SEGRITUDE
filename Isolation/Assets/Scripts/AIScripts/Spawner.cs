using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : MonoBehaviour {

    public GameObject swatPrefab;
    public GameObject area;
    public int maxEnemies;

    private int currentEnemies;

    private void Update() {
        SpawnEnemies();
    }

    void SpawnEnemies (){
        if (CheckAmountOfEnemies()) {
            GameObject swat = (GameObject)Instantiate(swatPrefab, this.transform.position, this.transform.rotation);
            swat.GetComponent<AIController>().area = area;
            currentEnemies++;
        }
    }

    bool CheckAmountOfEnemies() {
        if (currentEnemies < maxEnemies) {
            return true;
        } else {
            return false;
        }
    }
}
