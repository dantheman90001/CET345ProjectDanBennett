using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class EnemyChasesPlayerWhenNearby : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float moveSpeed;
    public float howClose;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        {
            dist = Vector3.Distance(player.position, transform.position);
            if (dist > howClose)
            {
                //rigidbody.velocity = Vector3.zero;
            }
            else if (dist <= howClose && dist > 2f)
            {
                transform.LookAt(player);
                
                
            }
            else if (dist <= 2f)
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
