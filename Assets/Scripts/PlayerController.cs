using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRb;     //rigid body variable
    public Image GameOver;           //image variale
    private Animator PlayerAnim;          //animation variable
    private AudioSource playerAudio;       //audio variable
    public AudioClip jumpSound;             // audio clip variables
    public AudioClip crashSound;
    public AudioClip coinPickSound;


    private float gravityModifier = 2;      //gravity multiplier variable
    private int maxJumpCount = 1;            //jumps variable
    private int jumpsRemaining;
    private float jumpForce = 3;     //jump Force veriable
    private float playerMovement = 5;       //forward movement


    public bool upArrow = false;       //bools for left , right, up and down rotation
    public bool downArrow = false;
    public bool rightArrow = false;
    public bool leftArrow = false;


    public TMP_Text Text;       //score variables
    public int score;

     
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();          //getting animation
        PlayerRb = GetComponent<Rigidbody>();          //getting rigid body 
        playerAudio = GetComponent<AudioSource>();      //getting audio source
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.RightArrow))             //function checks if right arrow is pressed
        {
            leftArrow = false;
            rightArrow = true;
            upArrow = false;
            downArrow = false;

            // changing the angle to 180
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,      
            180 , gameObject.transform.eulerAngles.z);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))         //function checks if left arrow is pressed
        {
            leftArrow = true;
            rightArrow = false;
            upArrow = false;
            downArrow = false;

            // changing the angle to 0
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
            0 , gameObject.transform.eulerAngles.z);
        }
 
        if(Input.GetKeyDown(KeyCode.UpArrow))          //function checks if up arrow is pressed
        {
            leftArrow = false;
            rightArrow = false;
            upArrow = true;
            downArrow = false;

            // changing the angle to 90
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
            90 , gameObject.transform.eulerAngles.z);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))         //function checks if down arrow is pressed
        {
            leftArrow = false;
            rightArrow = false;
            upArrow = false;
            downArrow = true;

            // changing the angle to -90
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
            -90 , gameObject.transform.eulerAngles.z);
        }



        if(Input.GetKeyDown(KeyCode.Space) && upArrow && !gameOver && (jumpsRemaining > 0))
        { 
            PlayerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);    //jumping the player up by adding force
            PlayerAnim.SetTrigger("Jump_trig");          //jump trigger animation
            transform.position = transform.position + new Vector3(playerMovement , 0 , 0);       //player moving forward 
            playerAudio.PlayOneShot(jumpSound , 1);        //jump sound


            jumpsRemaining -= 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && downArrow && !gameOver && (jumpsRemaining > 0)) 
        { 
            PlayerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            PlayerAnim.SetTrigger("Jump_trig");
            transform.position = transform.position + new Vector3(-playerMovement , 0 , 0);
            playerAudio.PlayOneShot(jumpSound , 1);

            jumpsRemaining -= 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && rightArrow && !gameOver && (jumpsRemaining > 0)) 
        { 
            PlayerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            PlayerAnim.SetTrigger("Jump_trig");
            transform.position = transform.position + new Vector3(0 , 0 , -playerMovement);
            playerAudio.PlayOneShot(jumpSound , 1);

            jumpsRemaining -= 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && leftArrow && !gameOver && (jumpsRemaining > 0))
        { 
            PlayerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            PlayerAnim.SetTrigger("Jump_trig");
            transform.position = transform.position + new Vector3(0 , 0 , playerMovement);
            playerAudio.PlayOneShot(jumpSound , 1);

            jumpsRemaining -= 1;
        }

        Text.text = score.ToString();       //texr to string conversion
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))     //checking for the ground tag
        {
            jumpsRemaining = maxJumpCount;    
        }

        else if(collision.gameObject.CompareTag("Obstacle"))       //checking for the obstcle tag
        {
            gameOver = true;
            GameOver.gameObject.SetActive(true);           //Game Over Image

            PlayerAnim.SetBool("Death_b" , true);         //Death effect
            PlayerAnim.SetInteger("DeathType_int" , 1);


            playerAudio.PlayOneShot(crashSound , 1);     //Crash Sound
        }

        else if(collision.gameObject.CompareTag("Star"))        //checking for the ground star
        {
            Destroy(collision.gameObject);
            score++;
            playerAudio.PlayOneShot(coinPickSound , 1);
        }

    }
}

