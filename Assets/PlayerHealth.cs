using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxShield = 250;
    public float currentShield;
    public TMP_Text shieldUI;

    private WaitForSeconds regenShieldTick = new WaitForSeconds(0.1f);

    private Coroutine regenShield;
    public ShieldBar shieldBar;
    // Start is called before the first frame update
    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);      
    }

    private void OnTriggerEnter (Collider collideObject)
    {
        if(collideObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            TakeShieldDamage(20);
        }
    } 

    

    public void TakeShieldDamage(float damage)
    {
        currentShield -= damage;
        shieldBar.SetShield((int)currentShield);

        if (regenShield != null)
        {
            StopCoroutine(regenShield);
        }
         regenShield = StartCoroutine(RegenShield());
        if (currentShield <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        maxShield = Mathf.Clamp(maxShield, 1, 250);

        if (currentShield > maxShield)
        {
            currentShield = 250;
        }
    }

    private IEnumerator RegenShield()
    {
        yield return new WaitForSeconds(5);

        while(currentShield < maxShield)
        {
            currentShield += maxShield / 100;
            shieldBar.SetShield((int)currentShield);
            yield return regenShieldTick;
        }
        regenShield = null;
    }
}
