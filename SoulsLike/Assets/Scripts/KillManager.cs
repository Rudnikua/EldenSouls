using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager Instance;

    [Header("Kill Settings")]
    [SerializeField] private GameObject potralPrefab;

    [System.Serializable]
    public class PortalLocation {
        public string locationName = "Location 1";
        public int killsRequired;
        public Transform spawnPoint;
        public Transform teleportTarget;

        [HideInInspector]
        public bool hasSpawned = false; 
    }

    [Header("Portal Location Settings")]
    public List<PortalLocation> portalLocations;

    private int killCount = 0;

    private void Awake() {
        Instance = this;
    }
    public void AddKill() {
        killCount++;
        Debug.Log($"Kill Count: {killCount}");

        CheckForPortals();
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
    }
}
