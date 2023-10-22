using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public bool canSeePlayer;


    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private IEnumerator FOVRoutine()
    {
        //runs field of view check every 0.5 seconds
        float delay = -0.5f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        //checks if sphere (radius) of enemy overlaps with player in target mask layer is non zero
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0)
        {
            //then searches the normalised vector between enemy and target
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            //then if enemy forward vector and direction to target are within arc
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                //then determines distance between enemy and player
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                //then if raycast from enemy to player within distance is not obstructed
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    canSeePlayer = true;
                    Debug.Log("Game Over");
                }
                else
                    canSeePlayer = false;
                //Debug.Log("Unseen");
            }
            else
                canSeePlayer = false;
            //Debug.Log("Unseen");
        }
        else if (canSeePlayer)
            canSeePlayer = false;
        //Debug.Log("Unseen");
    }
}
