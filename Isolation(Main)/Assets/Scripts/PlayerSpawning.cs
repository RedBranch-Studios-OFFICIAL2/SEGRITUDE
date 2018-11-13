using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawning : MonoBehaviour {

    public int terrainTextureToSpawnPlayer;
    public GameObject player;
    public bool isDead;

    public GameObject respawnPanel;

    private Playeratt playeratt;

    public Terrain[] terrains;

    private float maxPlayerHealth;

    private int terrainLength;
    private int terrainWidth;
    private int terrainPosX;
    private int terrainPosZ;

    private List<Vector3> possibleSpawnLocations = new List<Vector3>();

    private void Start() {
        respawnPanel.SetActive(false);
        playeratt = GetComponent<Playeratt>();
        maxPlayerHealth = playeratt.Health;
        terrains = Object.FindObjectsOfType<Terrain>();
        
        foreach (Terrain terrain in terrains) {
            GetPossiblePositions(terrain);
        }
        
    }

    private void Update() {
        if (playeratt.Health <= 0 || isDead) {
            respawnPanel.SetActive(true);
        } else {
            respawnPanel.SetActive(false);
        }
    }

    void SpawnPlayer() {
        int randomIndex = Random.Range(0, possibleSpawnLocations.Count);

        Vector3 spawnLocation = possibleSpawnLocations[randomIndex];
        //float posY = terrain.SampleHeight(spawnLocation);
        spawnLocation.y = /*posY*/ + player.transform.localScale.y / 2;

        GameObject playerSpawn = (GameObject)Instantiate(player, spawnLocation, Quaternion.identity);
    }

    //Get all possible positions that a player can spawn
    void GetPossiblePositions(Terrain terrain) {

        terrainLength = (int)terrain.terrainData.size.x;
        terrainWidth = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;

        for (int x = 0; x < terrainLength; x++) {
            for (int z = 0; z < terrainWidth; z++) {
                Vector3 checkPos = new Vector3(terrainPosX + x, 0, terrainPosZ + z);
                int textureIndexAtCheckPos = TerrainSurface.GetMainTexture(checkPos, terrain);

                if (textureIndexAtCheckPos == terrainTextureToSpawnPlayer) {
                    possibleSpawnLocations.Add(checkPos);
                }
            }
        }
    }

    public void RespawnButton() {
        SpawnPlayer();
        playeratt.Health = maxPlayerHealth;
        respawnPanel.SetActive(false);
        DestroyImmediate(this.gameObject, true);      
    }

}
