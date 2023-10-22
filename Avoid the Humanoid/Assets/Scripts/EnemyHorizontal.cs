using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : MonoBehaviour
{

    public float speedHorizontal = 5;
    public float xLimit = 47;
    private Rigidbody enemyRB;
    public bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    { 
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moveRight && transform.position.x < xLimit)
        {
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            //Debug.Log("Move Right = " + moveRight + " and moving right");
        }

        if (moveRight && transform.position.x > (xLimit - 1))
        {
            moveRight = false;
            transform.Rotate(0, 180, 0);
            //Debug.Log("Move Right = " + moveRight);
        }

        if (!moveRight && transform.position.x > -xLimit)
        {
            //Debug.Log("Move Right = " + moveRight + " and moving left");
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
        }

        if (!moveRight && transform.position.x < (-xLimit + 1))
        {
            moveRight = true;
            transform.Rotate(0, 180, 0);
            //Debug.Log("Move Right = " + moveRight);
        }
        }
}
