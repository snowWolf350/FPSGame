using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    float health;
    float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2;

    public Image frontHealthBar;
    public Image backHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(health,0, maxHealth);
        updateHealthUI();
    }
    public void updateHealthUI()
    {   
        float fHealth = frontHealthBar.fillAmount;
        float bHealth = backHealthBar.fillAmount;
        float hfraction = health / maxHealth;

        if (bHealth > hfraction)
        {
            backHealthBar.color = Color.red;
            frontHealthBar.fillAmount = hfraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(bHealth, hfraction, percentComplete);
        }
        if (fHealth < hfraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hfraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete *= percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fHealth,hfraction,percentComplete);
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        lerpTimer = 0;
    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        if (health > 100)
        {
            health = 100;
        }
        lerpTimer = 0;
    }
}
