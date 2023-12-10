using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    public float speedHorizontal = 5;
    public float zRange = 70; //how far enemy will travel
    private Rigidbody enemyRB;
    public bool moveForward = true; //bool to determine enemy direction
    private Vector3 startingPos;
    public AudioClip mumble;
    public AudioClip whatThe;
    private AudioSource enemyAudio;
    private bool gameOver = false;

    private DotProductScript dotProductScript;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //determine starting position of the enemy
        startingPos = transform.position;

        dotProductScript = GetComponent<DotProductScript>();
        enemyAudio = GetComponent<AudioSource>();
        enemyAudio.clip = mumble; //starts the enemy mumbling
        enemyAudio.loop = true;
        enemyAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
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

    public void EnemyMovement()
    { 
        //translation details for the enemies including debug logs to check
        if (moveForward && transform.position.z < (startingPos.z + (zRange)))
        {
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            //Debug.Log("Move Forward = " + moveForward + " and moving forward");
        }

        if (moveForward && transform.position.z > (startingPos.z + (zRange - 1)))
          {
             moveForward = false;
            transform.Rotate(0, 180, 0);
             //Debug.Log("Move Forward = " + moveForward);
        }

          if (!moveForward && transform.position.z > startingPos.z)
          {
             //Debug.Log("Move Forward = " + moveForward + " and moving backwards");
             transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
        }

        if (!moveForward && transform.position.z < (startingPos.z + 1))
            {
            moveForward = true;
            transform.Rotate(0, 180, 0);
            //Debug.Log("Move Forward = " + moveForward);
        }
    }
}