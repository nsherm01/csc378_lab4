using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float curHealth;
    public float maxHealth;

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        healthBar.fillAmount = curHealth / maxHealth;
    }

    public void Heal(float healAmount)
    {
        curHealth += healAmount;
        curHealth = Mathf.Clamp(curHealth, 0f, maxHealth);
        healthBar.fillAmount = curHealth / maxHealth;
    }
}
