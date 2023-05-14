using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryHealth : MonoBehaviour
{
    public float sentryStartHealth = 100f;
    public AudioSource damagedSound;


     void Start()
    {
        damagedSound = GetComponent<AudioSource>();
    }
    public void TakeSentryDamage(float amount)
    {
        sentryStartHealth -= amount;
        damagedSound.Play();
        if (sentryStartHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
