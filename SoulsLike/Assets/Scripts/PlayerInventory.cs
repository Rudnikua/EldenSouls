using StarterAssets;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public static PlayerInventory Instance {get ; private set;}

    public event EventHandler<PotionCountChangedEventArgs> OnPotionCountChanged;

    private const string HEAL = "Heal";

    [SerializeField] private int maxPotions = 3;
    [SerializeField] private float healAmount = 25f;
    [SerializeField] private GameObject healPotionHolder;
    [SerializeField] private GameObject healPotionModel;

    private Animator animator;
    private HealthSystem healthSystem;
    private StarterAssetsInputs starterAssetsInputs;
    private int currentPotions = 0;

    private GameObject currentPotionInHand;

    public int CurrentPotions => currentPotions;
    public bool CanPickUpPotion() => currentPotions < maxPotions;
    public bool CanUsePotion() => currentPotions > 0 && healthSystem.CurrentHealth < healthSystem.MaxHealth && !healthSystem.IsInvulnerable && healthSystem.CurrentHealth > 0;
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update() {
        OnHeal();
    }
    public void AddPotion() {
        if (currentPotions < maxPotions) {
            currentPotions++;

            OnPotionCountChanged?.Invoke(this, new PotionCountChangedEventArgs(currentPotions));
        }
    }

    private void UsePotion() {
        if (!CanUsePotion()) return;

        currentPotions--;

        OnPotionCountChanged?.Invoke(this, new PotionCountChangedEventArgs(currentPotions));

        healthSystem.Heal(healAmount);
    }

    private void OnHeal() {
        if (starterAssetsInputs.heal && CanUsePotion()) {
            animator.SetBool(HEAL, true);
            starterAssetsInputs.heal = false;
        }
    }
    public void OnHealStarted() {
        currentPotionInHand = Instantiate(healPotionModel, healPotionHolder.transform);
    }
    public void OnHealUsed() {
        UsePotion();
    }
    public void OnHealFinished() {
        starterAssetsInputs.heal = false;
        animator.SetBool(HEAL, false);
        Destroy(currentPotionInHand);
    }
}
