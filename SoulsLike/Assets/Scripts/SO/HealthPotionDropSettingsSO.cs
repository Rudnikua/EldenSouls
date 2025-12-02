using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotionDrop", menuName = "Loot/Health Potion Drop")]
public class HealthPotionDropSettingsSO : ScriptableObject
{
    [Range(0f, 100f)] public float dropChance = 30f;
    public GameObject healthPotionPrefab;
}
