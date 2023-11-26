using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{

    public float speedHorizontal = 5;
    public float xLimit = 47; //houndaries of enemy movement
    private Rigidbody enemyRB;
    public bool moveRight = true;
    public bool moveLeft = false;
    public AudioClip mumble;
    public AudioClip whatThe;
    private AudioSource enemyAudio;
    private bool gameOver = false;
    public Animator anim;

    private DotProductScript dotProductScript;

    // Start is called before the first frame update
    void Start()
    {
        dotProductScript = GetComponent<DotProductScript>();
        enemyAudio = GetComponent<AudioSource>();
        enemyAudio.clip = mumble; //starts the enemy mumbling
        enemyAudio.loop = true;
        enemyAudio.Play();
        this.anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {

        if (dotProductScript.canSeePlayer && gameOver == false)
        {
            enemyAudio.Stop(); //stops mumble
            enemyAudio.PlayOneShot(whatThe); //plays the "what the"
            gameOver = true; //stops the what the looping heavily
        }
            

        //horizontal movement based on xLimits with debug logs
        if (moveRight && transform.position.x < xLimit)
        {
            
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            this.anim.SetBool("isWalking", true);
            Debug.Log("Move Right = " + moveRight + " and moving right");
        }

        if (moveRight && transform.position.x > (xLimit - 1))
        {
            
            moveRight = false;
            moveLeft = true;
            transform.Rotate(0, 180, 0);
            Debug.Log("Move Right = " + moveRight);
        }

        if (!moveRight && transform.position.x > -xLimit)
        {
            Debug.Log("Move Right = " + moveRight + " and moving left");
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            this.anim.SetBool("isWalking", true);
        }

        if (!moveRight && transform.position.x < (-xLimit + 1))
        {
            moveRight = true;
            moveLeft = false;
            transform.Rotate(0, 180, 0);
            Debug.Log("Move Right = " + moveRight);
        }
        }
}
