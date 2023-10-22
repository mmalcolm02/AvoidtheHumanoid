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
        //if (canSeePlayer)
        //{
        //    Debug.Log("Seen");
       // }
       // else
         //   Debug.Log("Unseen");
    }

    private IEnumerator FOVRoutine()
    {
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
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    canSeePlayer = true;
                    Debug.Log("Seen");
                }
                else
                    canSeePlayer = false;
                Debug.Log("Blocked");
            }
            else
                canSeePlayer = false;
            Debug.Log("OutofArc");
        }
        else if (canSeePlayer)
            canSeePlayer = false;
        Debug.Log("Too far");
    }
}
