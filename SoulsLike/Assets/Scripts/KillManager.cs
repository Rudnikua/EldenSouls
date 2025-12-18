using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class KillManager : MonoBehaviour
{
    public static KillManager Instance;

    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private TextMeshProUGUI portalNotifierText;
    [SerializeField] private float notificationDuration = 3f;

    [Header("Kill Settings")]
    [SerializeField] private GameObject potralPrefab;

    private Coroutine currentNotificationCoroutine;

    [System.Serializable]
    public class PortalLocation {
        public string locationName = "Location 1";
        public int killsRequired;
        public Transform spawnPoint;
        public Transform teleportTarget;

        public string notificationMessage = "PORTAL TO THE NEXT LOCATION HAS SPAWNED";

        [HideInInspector]
        public bool hasSpawned = false; 
    }

    [Header("Portal Location Settings")]
    public List<PortalLocation> portalLocations;

    private int killCount = 0;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        UpdateKillText();

        if (portalNotifierText != null) {
            portalNotifierText.gameObject.SetActive(false);
        }
    }
    public void AddKill() {
        killCount++;

        UpdateKillText();

        CheckForPortals();
    }

    private void UpdateKillText() {
        if (killCountText != null) {
            killCountText.text = $"Kills: " + killCount.ToString();
        }
    }
    private void CheckForPortals() {
        foreach (var location in portalLocations) {
            if (!location.hasSpawned && killCount >= location.killsRequired) {
                SpawnPortal(location);
                location.hasSpawned = true;
            }
        }
    }

    private void SpawnPortal(PortalLocation location) {
        if (potralPrefab == null || location.spawnPoint == null) {
            Debug.LogWarning("Portal prefab or spawn point is not assigned.");
            return;
        }

        GameObject portal = Instantiate(potralPrefab, location.spawnPoint.position, location.spawnPoint.rotation);

        PortalTeleport teleportTo = portal.GetComponent<PortalTeleport>();
        if (teleportTo != null) {
            teleportTo.teleportTarget = location.teleportTarget;
        }

        Debug.Log($"Portal spawned at {location.locationName} after reaching {location.killsRequired} kills.");

        if (portalNotifierText != null) {
            if (currentNotificationCoroutine != null) {
                StopCoroutine(currentNotificationCoroutine);
            }
            currentNotificationCoroutine = StartCoroutine(ShowPortalNotificationRoutine(location.notificationMessage));
        }
    }

    private IEnumerator ShowPortalNotificationRoutine(string message) {
        portalNotifierText.text = message;
        portalNotifierText.gameObject.SetActive(true);
        yield return new WaitForSeconds(notificationDuration);
        portalNotifierText.gameObject.SetActive(false);
    }
}
