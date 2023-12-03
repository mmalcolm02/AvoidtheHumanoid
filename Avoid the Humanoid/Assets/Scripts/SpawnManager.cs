using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject carPrefab;
    public Vector3 spawnPosLeft = new Vector3(-98, 6, 136);
    public Vector3 spawnPosRight = new Vector3(98, 6, 116);
    public float eulerX;
    public float eulerY;
    public float eulerZ;
    public float eulerRX;
    public float eulerRY;
    public float eulerRZ;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("InstantiateLeft", 1);
        Invoke("InstantiateRight", 1);

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void InstantiateLeft()
    {
        float leftTime = Random.Range(2, 5);
        Instantiate(carPrefab, spawnPosLeft, Quaternion.Euler(new Vector3(eulerRX, eulerRY, eulerRZ)));
        Debug.Log("Left");
        Invoke("InstantiateLeft",leftTime);
        
}
    void InstantiateRight()
    {
        float rightTime = Random.Range(2, 5);
        Instantiate(carPrefab, spawnPosRight, Quaternion.Euler(new Vector3(eulerX,eulerY,eulerZ)));
        Debug.Log("Right");
        Invoke("InstantiateRight", rightTime);
    }

}
