using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotational : MonoBehaviour
{

   
    public float angleOfRotation = -45.0f;
    public float rotationDelay = 3.0f;

    public AudioClip mumble;
    public AudioClip whatThe;
    private AudioSource enemyAudio;

    public FieldOfView fovScript;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotationControl());

        fovScript = GetComponent<FieldOfView>();
        enemyAudio = GetComponent<AudioSource>();
        enemyAudio.clip = mumble; //starts the enemy mumbling
        enemyAudio.loop = true;
        enemyAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (fovScript.canSeePlayer && gameOver == false)
        {
            enemyAudio.Stop(); //stops mumble
            enemyAudio.PlayOneShot(whatThe); //plays the "what the"
            gameOver = true; //stops the what the looping heavily
        }
    }

    //coroutine to rotate the enemy back and forth every seconds equal to rotationDelay
    IEnumerator RotationControl()
    {
        yield return new WaitForSeconds(rotationDelay);
        transform.Rotate(0, (angleOfRotation), 0);
        angleOfRotation = -angleOfRotation;
        StartCoroutine(RotationControl());


    }

    
}
