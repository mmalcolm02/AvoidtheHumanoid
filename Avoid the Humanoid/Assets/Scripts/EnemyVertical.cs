using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    public float speedHorizontal = 5;
    public float zLimit = 35;
    private Rigidbody enemyRB;
    public bool moveForward = true;
    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (moveForward && transform.position.z < (startingPos.z + (2 * zLimit)))
        {
            transform.Translate(Vector3.forward * speedHorizontal * Time.deltaTime);
            //Debug.Log("Move Forward = " + moveForward + " and moving forward");
        }

        if (moveForward && transform.position.z > (startingPos.z + (2 * zLimit - 1)))
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