using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool hasPowerUp;
    public float powerUpStrength = 15.0f;
    public Rigidbody playerRb;
    public GameObject focalPoint;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point"); 
        playerRb = GetComponent<Rigidbody>();
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //resting position
        if(Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.T))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
        }
        StartCoroutine(PowerupCountdownRoutine());
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = (enemyRb.transform.position - transform.position);
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
