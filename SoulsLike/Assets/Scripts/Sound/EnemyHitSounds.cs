using UnityEngine;

public class EnemyHitSounds : MonoBehaviour
{
    [Header("Hit Sounds")]
    public AudioClip[] heavyHitSounds;

    [Range(0f, 1f)]
    public float volume = 1f;

    public void PlayHeavyHit()
    {
        if (heavyHitSounds == null || heavyHitSounds.Length == 0)
            return;

        AudioClip clip = heavyHitSounds[Random.Range(0, heavyHitSounds.Length)];

        GameObject audioGO = new GameObject("EnemyHitSound");
        audioGO.transform.position = transform.position;

        AudioSource src = audioGO.AddComponent<AudioSource>();
        src.clip = clip;
        src.volume = volume;
        src.spatialBlend = 1f;
        src.minDistance = 0.8f;
        src.maxDistance = 6f;
        src.pitch = Random.Range(0.9f, 1.1f);
        src.Play();

        Destroy(audioGO, clip.length);
    }
}
