using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private GameObject pausePanel;
    public void OnResumeButton()
    {
        if (playerInput != null)
        {
            pausePanel.SetActive(false);
            playerInput.ResumeGame();
        }
    }

    public void OnMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
