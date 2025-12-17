using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    public static UISoundManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource audioSource;

    [Header("UI Sounds")]
    public AudioClip clickSound;
    public AudioClip openMenuSound;
    public AudioClip closeMenuSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource.ignoreListenerPause = true;
            audioSource.spatialBlend = 0f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClick()
    {
        Play(clickSound);
    }

    public void PlayMenuOpen()
    {
        Play(openMenuSound);
    }

    public void PlayMenuClose()
    {
        Play(closeMenuSound);
    }

    private void Play(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip);
    }
}
