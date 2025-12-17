using StarterAssets;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathMenu : MonoBehaviour {

    [SerializeField] private GameObject bossDeathMenuUI;
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private AudioClip victoryMusic;
    private void Start() {
        if (bossDeathMenuUI == null) {
            Debug.LogError("[DeathMenu] Death Menu UI is not assigned in the inspector.");
        }
        bossDeathMenuUI.SetActive(false);

        HealthSystem.OnBossDeath += HealthSystem_OnBossDeath;
    }

    private void HealthSystem_OnBossDeath(object sender, System.EventArgs e) {
        AudioManager.Instance.PlayMusic(victoryMusic);
        ShowWinScreen();
    }

    public void OnMainMenuButton() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void ShowWinScreen() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        bossDeathMenuUI.SetActive(true);
    }

    private void OnDestroy() {
        HealthSystem.OnBossDeath -= HealthSystem_OnBossDeath;
    }

}
