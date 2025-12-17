using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public AudioClip teleportSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (teleportSound != null)
            {
                audioSource.PlayOneShot(teleportSound);
            }

            
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
            }

            
            other.transform.position = teleportTarget.position;
            Debug.Log("Player teleported!");

            
            if (cc != null)
            {
                cc.enabled = true;
            }
        }
    }
}
