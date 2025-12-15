using System.Collections;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Combat")]
    public AudioClip swordDrawSound;
    public AudioClip swordSwingSound;
    public AudioClip deathSound;

    [Header("Movement")]
    public AudioClip[] runStepSounds;
    public AudioClip jumpSound;

    [Header("Run Settings")]
    public float runSpeedThreshold = 0.1f;
    public Vector2 runStepInterval = new Vector2(0.35f, 0.55f);

    private CharacterController characterController;
    private bool isDead;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        StartCoroutine(RunStepsRoutine());
    }

    public void PlaySwordDraw()
    {
        if (swordDrawSound != null)
            audioSource.PlayOneShot(swordDrawSound);
    }

    public void PlaySwordSwing()
    {
        if (swordSwingSound != null)
            audioSource.PlayOneShot(swordSwingSound);
    }

    public void PlayJump()
    {
        if (jumpSound != null)
            audioSource.PlayOneShot(jumpSound);
    }

    public void PlayDeath()
    {
        if (isDead) return;
        isDead = true;

        if (deathSound != null)
            audioSource.PlayOneShot(deathSound);
    }
    private IEnumerator RunStepsRoutine()
    {
        while (!isDead)
        {
            if (IsRunning())
            {
                PlayRandomRunStep();
                float wait = Random.Range(runStepInterval.x, runStepInterval.y);
                yield return new WaitForSeconds(wait);
            }
            else
            {
                yield return null;
            }
        }
    }

    private bool IsRunning()
    {
        if (characterController == null) return false;
        return characterController.velocity.magnitude > runSpeedThreshold &&
               characterController.isGrounded;
    }

    private void PlayRandomRunStep()
    {
        if (runStepSounds == null || runStepSounds.Length == 0) return;
        AudioClip clip = runStepSounds[Random.Range(0, runStepSounds.Length)];
        audioSource.PlayOneShot(clip);
    }
}
