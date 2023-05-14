using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGEnemyHealth : MonoBehaviour
{
    public float SMGEnemyStartHealth = 100f;
    public AudioSource damagedSound;

     void Start()
    {
        damagedSound = GetComponent<AudioSource>();
    }

    public void TakeSMGEnemyDamage(float amount)
    {
        SMGEnemyStartHealth -= amount;
        damagedSound.Play();
        if (SMGEnemyStartHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
