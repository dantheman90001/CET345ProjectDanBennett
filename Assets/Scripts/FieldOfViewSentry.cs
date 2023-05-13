using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewSentry : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;
    public GameObject playerRef;
    public LayerMask playerMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
    public Transform player;

    public float sentryDamage = 40f;
    public float range = 60f;
    public Transform sentryStart;
    public LineRenderer laserLine;
    public float fireRate = 1f;
    public float nextFire;
    public WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    public bool isFiring;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRountine());
        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        laserLine.SetPosition(0, sentryStart.position);

        if(Physics.Raycast(sentryStart.transform.position, sentryStart.transform.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.DrawLine(sentryStart.transform.position, sentryStart.transform.forward, Color.white);
            PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeShieldDamage(sentryDamage);
            }
        }
        else
        {
            laserLine.SetPosition(1, sentryStart.transform.position + (sentryStart.transform.forward * range));
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, playerMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    transform.LookAt(player);
                    if (Time.time > nextFire && !isFiring)
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
