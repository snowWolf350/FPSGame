using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    float health;
    float lerpTimer;
    [Header("HealthBar")]
    public float maxHealth = 100;
    public float chipSpeed = 2;

    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI HealthText;

    [Header("DamageOverlay")]
    public Image Overlay;
    float duration = 1;
    float fadeSpeed = 1.5f;

    float durationTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(health,0, maxHealth);
        updateHealthUI();

        if (Overlay.color.a > 0)
        {
            if (health < 30)
            {
                return;
            }
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = Overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                Overlay.color = new Color(Overlay.color.r,Overlay.color.g,Overlay.color.b,tempAlpha);
            }
        }
    }
    public void updateHealthUI()
    {   
        float fHealth = frontHealthBar.fillAmount;
        float bHealth = backHealthBar.fillAmount;
        float hfraction = health / maxHealth;
        HealthText.text = health.ToString() + "/100";

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
        Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, 1);
        durationTimer = 0;
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
