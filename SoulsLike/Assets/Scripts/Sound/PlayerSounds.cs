using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Sword Sounds")]
    public AudioClip[] swordDrawSounds;  
    public AudioClip[] swordSwingSounds;
    public AudioClip[] swordSheathSounds;

    [Header("Damage Sounds")]
    public AudioClip[] damageSounds;

    [Header("Roll Sound")]
    public AudioClip rollsound;

    [Header("Death Sound")]
    public AudioClip deathSound;

    private bool isDead = false;


    public void PlaySwordDraw()
    {
        PlayRandomClip(swordDrawSounds);
    }
    public void PlaySwordSwing()
    {
        PlayRandomClip(swordSwingSounds);
    }

    public void PlaySwordSheath()
    {
        PlayRandomClip(swordSheathSounds);
    }

    public void PlayDamage()
    {
        if (isDead) return;
        PlayRandomClip(damageSounds);
    }

    public void PlayRoll()
    {
        if (rollsound == null) return;
        
        float originalPitch = audioSource.pitch;
        audioSource.pitch = 1f;

        audioSource.PlayOneShot(rollsound, 1f);
        audioSource.pitch = originalPitch;

    }

    public void PlayDeath()
    {
        if (deathSound == null) return;

        GameObject audioGO = new GameObject("PlayerDeathSound");
        audioGO.transform.position = transform.position;

        AudioSource src = audioGO.AddComponent<AudioSource>();
        src.clip = deathSound;
        src.spatialBlend = 1f;
        src.minDistance = 1f;
        src.maxDistance = 5f;
        src.Play();

        Destroy(audioGO, deathSound.length);
    }

    private void PlayRandomClip(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0) return;

        AudioClip clip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip, 1f);
    }
}

