using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 47, 0);

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        //follow the player from above, only z translation so the whole hoizontal level width visible
        transform.position = new Vector3(0,0,player.transform.position.z) + offset;

    }
}
