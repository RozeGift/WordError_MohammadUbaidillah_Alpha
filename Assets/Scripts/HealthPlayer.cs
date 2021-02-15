using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public Text healthtext;
    public Image healthBar;

    bool healthfull = true;
    public static float health, maxHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthtext.text =health + "%";
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        Testing();
        ColorChange();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void ColorChange()
    {
        Color healthColor = Color.Lerp(Color.red ,Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }


    //For now we are using SPACE as to check wether the health UI is working
    void Testing()
    {
        if(Input.GetKeyDown(KeyCode.Space) && healthfull)
        {
            health -= 10;
        }
        if(health <= 0)
        {
            healthfull = false;
        }
    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }

    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
}
