using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawning : MonoBehaviour {

    public Terrain terrain;
    public int terrainTextureToSpawnPlayer;
    public GameObject player;
    public bool isDead;

    public GameObject respawnPanel;

    public List<Vector3> possibleSpawnLocations = new List<Vector3>();

    private float playerHealth;
    private float maxPlayerHealth;

    private int terrainLength;
    private int terrainWidth;
    private int terrainPosX;
    private int terrainPosZ;

    private void Start() {
        terrainLength = (int)terrain.terrainData.size.x;
        terrainWidth = (int)terrain.terrainData.size.z;
        terrainPosX = (int)terrain.transform.position.x;
        terrainPosZ = (int)terrain.transform.position.z;
        GetPossiblePositions();
    }

    private void Update() {
        if (isDead) {
            respawnPanel.SetActive(true);
        } else {
            respawnPanel.SetActive(false);
        }
    }

    void SpawnPlayer() {
        int randomIndex = Random.Range(0, possibleSpawnLocations.Count);

        Vector3 spawnLocation = possibleSpawnLocations[randomIndex];
        float posY = terrain.SampleHeight(spawnLocation);
        spawnLocation.y = posY + player.transform.localScale.y / 2;

        GameObject playerSpawn = (GameObject)Instantiate(player, spawnLocation, Quaternion.identity);
    }

    //Get all possible positions that a player can spawn
    void GetPossiblePositions() {
        for (int x = 0; x < terrainLength; x++) {
            for (int z = 0; z < terrainWidth; z++) {
                Vector3 checkPos = new Vector3(terrainPosX + x, 0, terrainPosZ + z);
                int textureIndexAtCheckPos = TerrainSurface.GetMainTexture(checkPos);

                if (textureIndexAtCheckPos == terrainTextureToSpawnPlayer) {
                    possibleSpawnLocations.Add(checkPos);
                }
            }
        }
    }

    public void RespawnButton() {
        SpawnPlayer();
        isDead = false;
        respawnPanel.SetActive(false);
    }

}
