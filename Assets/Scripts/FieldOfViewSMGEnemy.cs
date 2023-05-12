using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfViewSMGEnemy : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask playerMask;

    public LayerMask obstructionMask;


    public bool canSeePlayer;

    public Transform player;
    public NavMeshAgent agent;


    public float enemySMGDamage = 40f;
    public float range = 40f;
    public Transform smgStart;
    public LineRenderer laserLine;
    public float fireRate = 2f;
    public float nextFire;
    public WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    public bool isFiring;
    
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRountine());
        laserLine = GetComponent<LineRenderer>();

    }

    private IEnumerator shotDelay()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
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

    
    void Shoot()
    {
       
        RaycastHit hit;
        laserLine.SetPosition(0, smgStart.position);

        if (Physics.Raycast(smgStart.transform.position, smgStart.transform.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.DrawLine(smgStart.transform.position, smgStart.transform.forward, Color.white);
            //Debug.Log(hit.transform.name);
            //ShieldBar shieldBar = hit.transform.GetComponent<ShieldBar>();
            PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeShieldDamage(enemySMGDamage);
            }

        }
        else
        {
            laserLine.SetPosition(1, smgStart.transform.position + (smgStart.transform.forward * range));
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
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    // When it spots the player
                    
                    canSeePlayer = true;
                    agent.SetDestination(player.position);
                    transform.LookAt(player);
                    if(Time.time > nextFire && !isFiring)
                    {
                        nextFire = Time.time + fireRate;
                        isFiring = true;
                        Shoot();
                        isFiring = false;
                        StartCoroutine(shotDelay());
                        
                    }
                    
                }
                else
                {
                    canSeePlayer = false;
                    agent.enabled = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
