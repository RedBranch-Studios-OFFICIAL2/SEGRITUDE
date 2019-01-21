using Segritude.Player;
using Segritude.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawning : MonoBehaviour {

    public int terrainTextureToSpawnPlayer;
    public GameObject player;
    public GameObject Cam;
    public bool isDead;

    public GameObject respawnPanel;

    private PlayerBehaviour playeratt;

    public Terrain[] terrains;

    private float maxPlayerHealth;

    private int terrainLength;
    private int terrainWidth;
    private int terrainPosX;
    private int terrainPosZ;

    private List<Vector3> possibleSpawnLocations = new List<Vector3>();
    private List<Vector3> possibleSpawnLocationHeight = new List<Vector3>();

    private void Start() {
        respawnPanel.SetActive(false);
        playeratt = GetComponent<PlayerBehaviour>();
        maxPlayerHealth = playeratt.Health;
        terrains = Object.FindObjectsOfType<Terrain>();
        
        foreach (Terrain terrain in terrains) {
            GetPossiblePositions(terrain);
        }
        
    }

    private void Update() {
        if (playeratt.Health <= 0 || isDead) {
            respawnPanel.SetActive(true);
            gameObject.GetComponent<ChaController>().speed = 0;
            CameraController.UseCamera = false;
        } else {
            respawnPanel.SetActive(false);
        }
    }

    void SpawnPlayer() {
        int randomIndex = Random.Range(0, possibleSpawnLocations.Count);

        Vector3 spawnLocation = new Vector3(possibleSpawnLocations[randomIndex].x, possibleSpawnLocationHeight[randomIndex].y + (transform.localScale.y/2), possibleSpawnLocations[randomIndex].z);

        GameObject playerSpawn = (GameObject)Instantiate(player, spawnLocation, Quaternion.identity);

        CameraController.UseCamera = true;
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
                    possibleSpawnLocationHeight.Add(new Vector3(0,terrain.SampleHeight(checkPos),0));
                }
            }
        }
    }

    public void RespawnButton() {
        SpawnPlayer();
        playeratt.Health = 100;
        respawnPanel.SetActive(false);
        DestroyImmediate(this.gameObject, true);
    }

}
