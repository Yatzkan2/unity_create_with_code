using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -9);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called once per frame and initialized after every Update() method
    void LateUpdate()
    {
        //Offset the camera behind the player adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
