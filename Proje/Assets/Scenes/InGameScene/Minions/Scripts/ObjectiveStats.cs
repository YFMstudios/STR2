using System.Collections;
using UnityEngine;

public class ObjectiveStats : MonoBehaviour
{
    [Header("Base Stats")]
    public float health;
    public float damage;

    public float damageLerpDuration;
    private float currentHealth;
    private float targetHealth;
    private Coroutine damageCoroutine;

    private float accumulatedDamage = 0; // Biriken hasar

    private HealthUII healthUII;

    private void Awake()
    {
        healthUII = GetComponent<HealthUII>();
        currentHealth = health;
        targetHealth = health;

        healthUII.Start3DSlider(health);
    }

    public void TakeDamage(float damageAmount)
    {
        // Hasarı biriktir
        accumulatedDamage += damageAmount;

        // Eğer coroutine çalışmıyorsa başlat
        if (damageCoroutine == null)
        {
            StartLerpHealth();
        }
    }

    private void HandleDeath()
    {
        if (gameObject.CompareTag("EnemyTurret"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void StartLerpHealth()
    {
        if (damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(LerpHealth());
        }
    }

    private IEnumerator LerpHealth()
    {
        while (accumulatedDamage > 0) // Biriken hasar bitene kadar işlem yap
        {
            float elapsedTime = 0;
            float initialHealth = currentHealth;

            // Hedef sağlık, biriken hasar kadar azalır
            targetHealth -= accumulatedDamage;
            accumulatedDamage = 0; // Biriken hasar sıfırlanır

            if (targetHealth <= 0)
            {
                targetHealth = 0;
                HandleDeath();
                break;
            }

            while (elapsedTime < damageLerpDuration)
            {
                currentHealth = Mathf.Lerp(initialHealth, targetHealth, elapsedTime / damageLerpDuration);
                UpdateHealthUI();
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            currentHealth = targetHealth;
            UpdateHealthUI();
        }

        damageCoroutine = null; // Coroutine tamamlanır
    }

    private void UpdateHealthUI()
    {
        healthUII.Update3DSlider(currentHealth);
    }
}
