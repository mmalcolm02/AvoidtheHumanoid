using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{

    public PlayerController player;
    public float yOffset = 48;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       transform.position = new Vector3 (0,yOffset, player.transform.position.z);


    }
}
