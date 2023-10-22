using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{

    private FieldOfView fov;

    // Start is called before the first frame update
    void Start()
    {

        fov = GetComponent<FieldOfView>();


    }

    // Update is called once per frame
    void Update()
    {

        if (fov.canSeePlayer == true)
        {
            Debug.Log("seen");
        }
        else
            Debug.Log("Unseen");
    }
}
