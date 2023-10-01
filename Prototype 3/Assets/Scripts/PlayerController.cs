using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public AudioSource backGroundMusic;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    private MoveLeft moveLeftScript;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    private bool gameOver = false;
    private int deathType = 1;
    private int doubleJumpCounter = 0;
    public float dashSpeedMove;
    public float dashSpeedAnim;
    public float startingSpeedMove;
    public float startingSpeedAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        moveLeftScript = new MoveLeft();
        //dashing
        startingSpeedAnim = playerAnim.speed;
        startingSpeedMove = moveLeftScript.Speed;
        dashSpeedAnim = playerAnim.speed * 1.5f;
        dashSpeedMove = moveLeftScript.Speed * 1.5f; 
        //modifying gravity
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //jumping by spacebar
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            doubleJumpCounter++;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if(doubleJumpCounter > 1)
            {
                isOnGround = false;           
            }
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }
        //dashing ability
        if(Input.GetKeyDown(KeyCode.S))
        {
           moveLeftScript.Speed = dashSpeedMove;
           playerAnim.speed  = dashSpeedAnim;
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            moveLeftScript.Speed = startingSpeedMove;
            playerAnim.speed = startingSpeedAnim;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        { 
            isOnGround = true;
            doubleJumpCounter = 0;
            dirtParticle.Play();
        }else 
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", deathType);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
            
            
            gameOver = true;
        }
    }
    public bool GameOver
    {
        get { return gameOver; }
        set {gameOver = value; }
    }
}