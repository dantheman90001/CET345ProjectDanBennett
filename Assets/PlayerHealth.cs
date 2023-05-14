using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Shield Bar")]
    public int maxShield = 250;
    public float currentShield;
    public TextMeshProUGUI shieldUI;

    private WaitForSeconds regenShieldTick = new WaitForSeconds(0.1f);

    private Coroutine regenShield;
    public ShieldBar shieldBar;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentShield = maxShield;
        shieldBar.SetMaxShield(maxShield);
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        shieldUI.GetComponent<TextMeshProUGUI>().text = "" + currentShield;
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
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.5f);

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
        shieldUI.text = currentShield.ToString();
        maxShield = Mathf.Clamp(maxShield, 1, 250);

        if (currentShield > maxShield)
        {
            currentShield = 250;
        }
        if (overlay.color.a > 0)
        {
            if (currentShield < 50)
            {
                return;
            }
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempALpha = overlay.color.a;
                tempALpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempALpha);
            }
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
