using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Находим CharacterController игрока
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;  // отключаем, чтобы не мешал телепорту
            }

            // Сам телепорт
            other.transform.position = teleportTarget.position;
            Debug.Log("Player teleported!");

            // Включаем обратно
            if (cc != null)
            {
                cc.enabled = true;
            }
        }
    }
}
