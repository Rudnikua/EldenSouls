using UnityEngine;
public class PickupSound : MonoBehaviour
{
    public AudioClip pickupSound;
    [Range(0f, 1f)] public float volume = 0.8f;

    public void Play()
    {
        if (pickupSound == null) return;

        GameObject audioGO = new GameObject("PickupSound");
        audioGO.transform.position = transform.position;

        AudioSource src = audioGO.AddComponent<AudioSource>();
        src.clip = pickupSound;
        src.volume = volume;
        src.spatialBlend = 1f;
        src.minDistance = 1f;
        src.maxDistance = 5f;
        src.Play();

        Destroy(audioGO, pickupSound.length);
    }
}
