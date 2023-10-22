using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float rangeX = 47;
    public float rangeZ = 207;
    public Rigidbody playerRB;

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
    }
    //Player Movement based on translate function
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.right * horizontalInput * speed);
        playerRB.AddForce(Vector3.forward * verticalInput * speed);
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