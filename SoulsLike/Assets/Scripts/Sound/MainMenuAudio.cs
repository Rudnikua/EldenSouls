using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public void PlayGame()
    {
        UISoundManager.Instance?.PlayClick();
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        UISoundManager.Instance?.PlayClick();
        Application.Quit();
    }
}
