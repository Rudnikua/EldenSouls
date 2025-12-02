using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager Instance;

    [Header("Kill Settings")]
    public int killCount = 0;
    public int killsToOpenPortal = 2;

    [Header("Portal Settings")]
    public GameObject portalPrefab;      
    public Transform portalSpawnPoint;    
    public Transform teleportTarget;     

    private void Awake()
    {
        Instance = this;
    }

    public void AddKill()
    {
        killCount++;
        Debug.Log("Kills: " + killCount);

        if (killCount >= killsToOpenPortal)
            SpawnPortal();
    }

    private void SpawnPortal()
    {
        if (portalPrefab == null || portalSpawnPoint == null)
        {
            Debug.LogWarning("Портал или точка спавна НЕ назначены!");
            return;
        }

        GameObject portal = Instantiate(portalPrefab, portalSpawnPoint.position, portalSpawnPoint.rotation);

        PortalTeleport tele = portal.GetComponent<PortalTeleport>();
        if (tele != null)
        {
            tele.teleportTarget = teleportTarget;
        }

        Debug.Log("Portal Spawned!");
    }
}
