using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth : MonoBehaviour
{
    public float sentryStartHealth = 100f;

    public void TakeSentryDamage(float amount)
    {
        sentryStartHealth -= amount;
        if (sentryStartHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
