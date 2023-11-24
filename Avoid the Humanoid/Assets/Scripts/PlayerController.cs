using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float rangeX = 47;
    public float rangeZ = 207;
    public Rigidbody playerRB;
    public Animator anim;

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
    }
    //Player Movement based on Add Force function
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = this.transform.forward * verticalInput + this.transform.right *
horizontalInput;
        movement.Normalize();

        this.transform.position += movement * 0.1f;

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
}