using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject currentObstacle;
    private GameObject player;
    private Vector3 spawnPosition;
    private int startDelay = 2;
    private int repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnObslacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

      
    }
    void SpawnObslacle()
    {
        if (playerControllerScript.GameOver == false)
        {
            int randObstacle = Random.Range(0, obstaclePrefab.Length);
            spawnPosition = obstaclePrefab[randObstacle].transform.position;
            currentObstacle = Instantiate(obstaclePrefab[randObstacle], spawnPosition, obstaclePrefab[randObstacle].transform.rotation);
            
        }
    }
    public GameObject CurrentObstacle
    {
        get { return currentObstacle; }
        set { currentObstacle = value; }
    }
}
