using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //spawning of car prefabs as enemy/obstacles
    public GameObject carPrefab;

    //Determines position cars spawn postion in Neighbourhood, and public to change values in Desert enviornment
    public Vector3 spawnPosLeft = new Vector3(-98, 6, 136);
    public Vector3 spawnPosRight = new Vector3(98, 6, 116);

    //eulers public to change rotation of cars in desert environment
    public float eulerX;
    public float eulerY;
    public float eulerZ;
    public float eulerRX;
    public float eulerRY;
    public float eulerRZ;



    // Begin the first instantiations of car prefabs entering from left and right
    void Start()
    {
        Invoke("InstantiateLeft", 1);
        Invoke("InstantiateRight", 1);

    }

    //after car instantiated these methods govern random spawn rate of future cars
    void InstantiateLeft()
    {
        float leftTime = Random.Range(2, 5);
        Instantiate(carPrefab, spawnPosLeft, Quaternion.Euler(new Vector3(eulerRX, eulerRY, eulerRZ)));
        //Debug.Log("Left");
        Invoke("InstantiateLeft",leftTime);
        
}
    void InstantiateRight()
    {
        float rightTime = Random.Range(2, 5);
        Instantiate(carPrefab, spawnPosRight, Quaternion.Euler(new Vector3(eulerX,eulerY,eulerZ)));
        //Debug.Log("Right");
        Invoke("InstantiateRight", rightTime);
    }

}
