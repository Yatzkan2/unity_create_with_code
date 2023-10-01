using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    private GameObject player;
    private GameObject currentObstacle;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Score: ");
        //Debug.Log(score);
        player = GameObject.Find("Player");
        currentObstacle = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().currentObstacle;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentObstacle.transform.position);
        //if(player.transform.position.x > currentObstacle.transform.position.x)
        //{
        //    score++;
        //    Debug.Log("Score: ");
        //    Debug.Log(score);
        //}
    }
}
