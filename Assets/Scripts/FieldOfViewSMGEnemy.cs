using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewSMGEnemy : MonoBehaviour
{
    public float radius;
    public float angle;

    public GameObject playerRef;

    public LayerMask playerMask;

    public LayerMask obstructionMask;

    public bool canSeePlayer;


    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRountine());
    }

    private IEnumerator FOVRountine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, playerMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {

            }
            else
            {
                canSeePlayer = false;
            }
        }
    }
}
