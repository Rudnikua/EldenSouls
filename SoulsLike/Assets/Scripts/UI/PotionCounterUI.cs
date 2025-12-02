using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionCounterUI : MonoBehaviour {

    [SerializeField] private Image potionIcon;
    [SerializeField] private TMP_Text potionCounterText;

    private void Start() {
        if (PlayerInventory.Instance != null) {
            PlayerInventory.Instance.OnPotionCountChanged += PlayerInventory_OnPotionCountChanged;
        } else {
            Debug.LogError("[PotionCounterUI] PlayerInventory not found");
        }
        potionIcon.gameObject.SetActive(PlayerInventory.Instance.CurrentPotions > 0);
    }
    private void PlayerInventory_OnPotionCountChanged(object sender, PotionCountChangedEventArgs e) {
        UpdateDisplay(e.CurrentPotions);
    }

    private void UpdateDisplay(int count) {
        if (potionIcon != null) {
            potionIcon.gameObject.SetActive(count > 0);
        }

        if (potionCounterText != null) {
            potionCounterText.gameObject.SetActive(count > 0);
            potionCounterText.text = count.ToString();
        }
    }

    private void OnDestroy() {
        if (PlayerInventory.Instance != null) {
            PlayerInventory.Instance.OnPotionCountChanged -= PlayerInventory_OnPotionCountChanged;
        }
    }
}
