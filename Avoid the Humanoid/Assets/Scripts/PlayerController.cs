using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player boundaries neighbourhood level
    public float speed = 10;
    public float rangeX = 47;
    public float rangeZ = 280;

    public Rigidbody playerRB;
    public Animator anim;

    //interaction with pop up screens
    public GameObject diedCanvas;
    public GameObject buttonHolderCanvas;
    public GameObject successCanvas;
    public GameObject timerCanvas;

    //detect collision
    public bool collision = false;

    //interact with end game animation
    public GameObject rocketOpen;
    public GameObject rocketClosed;


    public bool victory = false;
    public bool hasPebble = false;

    //switch camera on desert end from fp to overhead
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerContraints();
        Still();

        //planning pebble upgrade
        if (hasPebble && Input.GetKeyDown(KeyCode.Space))
        {
            //instantiate pebble
            hasPebble = false;

        }
    }
    //Player Movement based on transform however creates some collider issues
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = this.transform.forward * verticalInput + this.transform.right *
horizontalInput;
        movement.Normalize();

        this.transform.position += movement * 0.2f;

        this.anim.SetFloat("vertical", verticalInput);
        this.anim.SetFloat("horizontal", horizontalInput);
    }

    private void Still()
    {
       this.playerRB.AddForce(Vector3.down * 1 * Time.deltaTime, ForceMode.Impulse);
    }

    //Player Constrained by boundaries

    void PlayerContraints()
    {
        if (transform.position.x > rangeX)
        {
            transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -rangeX)
        {
            transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
        }
        if (transform.position.z > rangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rangeZ);
        }
        if (transform.position.z < -rangeZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -rangeZ);
        }
    }

    //player getting hit by car
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            //Debug.Log("Car Collision");
            collision = true;
            mainCamera.gameObject.SetActive(true);
            //this.ThirdPersonCamera.gameObject.SetActive(false);
            Destroy(gameObject);
            buttonHolderCanvas.gameObject.SetActive(true);
            diedCanvas.gameObject.SetActive(true);

        }

        //playercolliding with end goal - rocket
        if (other.gameObject.CompareTag("Rocket"))
        {
            collision = true;
            mainCamera.gameObject.SetActive(true);
            Destroy(gameObject);
            //Debug.Log("Rocket Collision");
            rocketOpen.gameObject.SetActive(false);
            rocketClosed.gameObject.SetActive(true);
            successCanvas.gameObject.SetActive(true);
            buttonHolderCanvas.gameObject.SetActive(true);
            timerCanvas.gameObject.SetActive(false);
            victory = true;
        }

    }

    //preparing to utilise power up - pebble
    private void OnCollisionEnter(Collision other)
    {
        collision = true;

        //testing pebble power up
        if (other.gameObject.CompareTag("Rocket"))
        {
            Destroy(other.gameObject);
            hasPebble = true;
        }
    }
}