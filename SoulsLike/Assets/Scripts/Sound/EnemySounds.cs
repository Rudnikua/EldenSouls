using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Sounds : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Combat Sounds")]
    public AudioClip attackSound;
    public AudioClip deathSound;

    [Header("Movement Sounds")]
    public AudioClip[] moveSounds;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(MoveSoundsRoutine());
    }
    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }
    public void PlayDeathSound()
    {
        if (deathSound == null) return;

        GameObject audioGO = new GameObject("EnemyDeathSound");
        audioGO.transform.position = transform.position;

        AudioSource src = audioGO.AddComponent<AudioSource>();
        src.clip = deathSound;
        src.spatialBlend = 1f;
        src.volume = 0.8f;
        src.minDistance = 1f;
        src.maxDistance = 5f;
        src.Play();

        Destroy(audioGO, deathSound.length);
    }



    public void PlayRandomMoveSound()
    {
        if (moveSounds.Length == 0) return;
        AudioClip randomMoveSound = moveSounds[Random.Range(0, moveSounds.Length)];
        audioSource.PlayOneShot(randomMoveSound, 0.25f);
    }

    
    private IEnumerator MoveSoundsRoutine()
    {
        while (true)
        {
            
            if (navMeshAgent != null && navMeshAgent.velocity.magnitude > 0.1f)
            {
                PlayRandomMoveSound();
            }

            
            float waitTime = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
