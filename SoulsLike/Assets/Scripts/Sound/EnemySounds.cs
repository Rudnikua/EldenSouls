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
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayRandomMoveSound()
    {
        if (moveSounds.Length == 0) return;
        AudioClip randomMoveSound = moveSounds[Random.Range(0, moveSounds.Length)];
        audioSource.PlayOneShot(randomMoveSound);
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
