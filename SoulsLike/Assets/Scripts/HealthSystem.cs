using System;
using UnityEngine;


public class HealthSystem : MonoBehaviour, IDamageable {
    
    public static HealthSystem Instance { get; private set; }  

    [Header("Health System")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private HealthPotionDropSettingsSO dropSettings;

    [SerializeField] private PlayerSounds playerSounds;

    private float currentHealth;

    public event EventHandler<HealthBarChangedEventArgs> OnHealthChanged;
    public event EventHandler<EventArgs> OnPlayerDeath;
    public static event EventHandler<EventArgs> OnBossDeath;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    public bool IsInvulnerable = false;  

    private void Awake() {
        if (isPlayer) Instance = this;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) {

        if (IsInvulnerable) return;   

        if (damage < 0) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        //Debug.Log($"<b>[{gameObject.name}]<b> - {damage}HP -> {currentHealth}/{maxHealth}");

        OnHealthChanged?.Invoke(this, new HealthBarChangedEventArgs(currentHealth, maxHealth));
        if (isPlayer)
        {
            playerSounds?.PlayDamage();
        }
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
            playerSounds?.PlayDeath();
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
        } else {
            Debug.Log($"{gameObject.name} died!");
            if (dropSettings != null && UnityEngine.Random.value * 100f < dropSettings.dropChance) {
                Instantiate(dropSettings.healthPotionPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
            KillManager.Instance?.AddKill();

            if (GetComponent<BossIdentifier>() != null) {
                OnBossDeath?.Invoke(this, EventArgs.Empty);
            }
            Sounds sounds = GetComponent<Sounds>();
            sounds?.PlayDeathSound();
            
            Destroy(gameObject);
        }
    }
}
