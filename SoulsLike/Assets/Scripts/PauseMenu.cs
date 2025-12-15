using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public StarterAssets.StarterAssetsInputs playerInput;
    public GameObject pausePanel;

    public void OnResumeButton()
    {
        Debug.Log("Нажата кнопка Продолжить");
        if (playerInput != null)
        {
            pausePanel.SetActive(false);
            playerInput.ResumeGame();
        }
    }

    public void OnMainMenuButton()
    {
        Debug.Log("Нажата кнопка Главное меню");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // поменяй на реальное имя сцены
    }

    public void OnQuitButton()
    {
        Debug.Log("Нажата кнопка Выход");
        Application.Quit();
    }
}
