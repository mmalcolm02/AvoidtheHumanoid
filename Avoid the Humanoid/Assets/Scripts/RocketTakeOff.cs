using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTakeOff : MonoBehaviour
{
    

   //rocket take off script

    // Update is called once per frame
    void Update()
    {
        //test game object is active, if yes then make it move
        if (gameObject.activeSelf)
        {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
    }
}
