using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool spawnDog;

    private void Start()
    {
        InvokeRepeating("EnableSpawnDog", 0, 3);
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spawnDog)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnDog = false;
        }
    }
    void EnableSpawnDog()
    {
        spawnDog = true;
    }
}
