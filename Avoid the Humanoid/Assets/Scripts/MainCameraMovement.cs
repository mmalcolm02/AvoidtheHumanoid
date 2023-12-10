using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{

    public PlayerController player;
    public float yOffset = 46;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       transform.position = new Vector3 (0,yOffset, player.transform.position.z);
        CameraPositionConstraint();

    }

    //method to restrict main camera movement in Level 1
    public void CameraPositionConstraint()
    {
        if (transform.position.z < -206)
        {
            transform.position = new Vector3(transform.position.x, yOffset, -206);
        }

        if (transform.position.z > 299)
        {
            transform.position = new Vector3(transform.position.x, yOffset, 299);
        }

       
    }
}
