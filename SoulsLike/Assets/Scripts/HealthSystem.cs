using System;
using UnityEngine;


public class HealthSystem : MonoBehaviour, IDamageable {

    [Header("Health System")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private HealthPotionDropSettingsSO dropSettings;

    private float currentHealth;

    public event EventHandler<HealthBarChangedEventArgs> OnHealthChanged;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    public bool IsInvulnerable = false;  

    private void Awake() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {

        if (IsInvulnerable) return;   

        if (damage < 0) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        //Debug.Log($"<b>[{gameObject.name}]<b> - {damage}HP -> {currentHealth}/{maxHealth}");

        OnHealthChanged?.Invoke(this, new HealthBarChangedEventArgs(currentHealth, maxHealth));

        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Heal(float amount) {
        if (amount <= 0) return;

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);

        OnHealthChanged?.Invoke(this, new HealthBarChangedEventArgs(currentHealth, maxHealth));
    }

    private void Die() {
        if (isPlayer) {
            Debug.Log("Player died! (GAME OVER)");
        } else {
            Debug.Log($"{gameObject.name} died!");
            if (dropSettings != null && UnityEngine.Random.value * 100f < dropSettings.dropChance) {
                Instantiate(dropSettings.healthPotionPrefab, transform.position + Vector3.up * 0.5f , Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
