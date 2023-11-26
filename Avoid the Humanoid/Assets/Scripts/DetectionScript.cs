using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{

    private DotProductScript dps;

    // Start is called before the first frame update
    void Start()
    {

        dps = GetComponent<DotProductScript>();


    }

    // Update is called once per frame
    void Update()
    {

        if (dps.canSeePlayer == true)
        {
            Debug.Log("seen");
        }
        else
            Debug.Log("Unseen");
    }
}
