using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotational : MonoBehaviour
{

    //rotatainal enemy behaviour variables
    public float angleOfRotation = -45.0f;
    public float rotationDelay = 3.0f;

    //access to mumbling sound effect
    public AudioClip mumble;
    public AudioClip whatThe;
    private AudioSource enemyAudio;

    //detection script link
    private DotProductScript dotProductScript;
    private bool gameOver = false;

    public Animator anim;

    // Start animations, sound effects and initial behaviour
    void Start()
    {

        this.anim.Play("Idle");
        StartCoroutine(RotationControl());

        dotProductScript = GetComponent<DotProductScript>();
        enemyAudio = GetComponent<AudioSource>();
        enemyAudio.clip = mumble; //starts the enemy mumbling
        enemyAudio.loop = true;
        enemyAudio.Play();
    }

    // Test if game is over against dot product script
    void Update()
    {

        if (dotProductScript.canSeePlayer && gameOver == false)
        {
            enemyAudio.Stop(); //stops mumble
            enemyAudio.PlayOneShot(whatThe); //plays the "what the"
            gameOver = true; //stops the what the looping heavily


        }

        if (gameOver)
        {
            this.anim.SetBool("isSurprised", true);
        }
    }

    //coroutine to rotate the enemy back and forth every seconds equal to rotationDelay
    IEnumerator RotationControl()
    {
        yield return new WaitForSeconds(rotationDelay);
        transform.Rotate(0, (angleOfRotation), 0);
        angleOfRotation = -angleOfRotation;
        if (!gameOver)
        {
            StartCoroutine(RotationControl());
        }
       

    }

    
}
