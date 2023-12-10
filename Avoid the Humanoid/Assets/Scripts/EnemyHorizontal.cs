using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{

    //original enemy and test bed for future interactions

    //movement variables
    public float speedHorizontal = 5;
    public float xLimit = 47; //houndaries of enemy movement

    //providing a rigid body - however redundant and refactor suggested
    private Rigidbody enemyRB;

    //variables to change direction
    public bool moveRight = true;
    public bool moveLeft = false;

    //sound effects
    public AudioClip mumble;
    public AudioClip whatThe;
    private AudioSource enemyAudio;

    //how to end each enemy interactions
    private bool gameOver = false;

    public Animator anim;

    //link to detection script
    private DotProductScript dotProductScript;

    // connect other script variables and set initial behaviour
    void Start()
    {
        dotProductScript = GetComponent<DotProductScript>();
        enemyAudio = GetComponent<AudioSource>();
        enemyAudio.clip = mumble; //starts the enemy mumbling
        enemyAudio.loop = true;
        enemyAudio.Play();
        this.anim.SetBool("isWalking", true);
    }

    // determine behaviour based whether player is visible or game is over
    void Update()
    {
        if (!gameOver) {
            EnemyMovement();

        }

        if (dotProductScript.canSeePlayer && gameOver == false)
        {
            enemyAudio.Stop(); //stops mumble
            enemyAudio.PlayOneShot(whatThe); //plays the "what the"
            gameOver = true; //stops the what the looping heavily
            this.anim.SetBool("isWalking", false);
            

        }

        if (gameOver)
        {
            this.anim.SetBool("isSurprised", true);
        }
    }

    //enemey movement behaviour including debug statements
    public void EnemyMovement() { 

        //horizontal movement based on xLimits with debug logs
        if (moveRight && transform.position.x < xLimit && !gameOver)
        {
            
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            this.anim.SetBool("isWalking", true);
            //Debug.Log("Move Right = " + moveRight + " and moving right");
        }

        if (moveRight && transform.position.x > (xLimit - 1) && !gameOver)
        {
            
            moveRight = false;
            moveLeft = true;
            transform.Rotate(0, 180, 0);
            //Debug.Log("Move Right = " + moveRight);
        }

        if (!moveRight && transform.position.x > -xLimit && !gameOver)
        {
            //Debug.Log("Move Right = " + moveRight + " and moving left");
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            this.anim.SetBool("isWalking", true);
        }

        if (!moveRight && transform.position.x < (-xLimit + 1) && !gameOver)
        {
            moveRight = true;
            moveLeft = false;
            transform.Rotate(0, 180, 0);
            //Debug.Log("Move Right = " + moveRight);
        }

        }
}
