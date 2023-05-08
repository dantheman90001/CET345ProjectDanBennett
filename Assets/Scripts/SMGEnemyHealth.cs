using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGEnemyHealth : MonoBehaviour
{
    public float SMGEnemyStartHealth = 100f;

    public void TakeSMGEnemyDamage(float amount)
    {
        SMGEnemyStartHealth -= amount;
        if (SMGEnemyStartHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
