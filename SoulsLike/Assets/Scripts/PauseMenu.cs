using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private GameObject pausePanel;

    private bool isOpen;

    public void TogglePauseMenu()
    {
        isOpen = !isOpen;
        pausePanel.SetActive(isOpen);

        if(isOpen)
        {
            UISoundManager.Instance?.PlayClick();
        }
        else
        {
            UISoundManager.Instance?.PlayClick();
        }
    }
    public void OnResumeButton()
    {
        if (playerInput != null)
        {
            UISoundManager.Instance?.PlayClick();
            pausePanel.SetActive(false);
            isOpen = false;
            playerInput.ResumeGame();
        }
    }

    public void OnMainMenuButton()
    {
        UISoundManager.Instance?.PlayClick();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButton()
    {
        UISoundManager.Instance?.PlayClick();
        Application.Quit();
    }
}
