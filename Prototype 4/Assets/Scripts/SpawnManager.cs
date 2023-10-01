using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerupPrefab;
    public int waveNumberCount;
    private float spawnRange = 9.0f;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        waveNumberCount = 1;// setting enemy wave start number
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//amount of enemies that are palying
        if(enemyCount == 0)
        {
            SpawnEnemyWave(waveNumberCount);
            waveNumberCount++;
            
        }
    }
    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
       
    } 
    public Vector3 GenerateSpawnPosition(float xRange, float yRange, float zRange)
    {
        float spawnPosX = Random.Range(-xRange, xRange);
        float spawnPosY = Random.Range(-yRange, yRange);
        float spawnPosZ = Random.Range(-zRange, zRange);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return spawnPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int i;
        for(i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemy, GenerateSpawnPosition(spawnRange, 0, spawnRange), enemy.transform.rotation);
        }
        SpawnPowerUp(); //spawnning new powerup every new wave
    }
    void SpawnPowerUp()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(spawnRange, 0, spawnRange), powerupPrefab.transform.rotation);
    }
    
    
}
