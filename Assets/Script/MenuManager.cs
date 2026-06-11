using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startUIPanel;
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        startUIPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // PLAY BUTTON SOUND
    public void PlayButtonSound()
    {
        AudioManager.Instance.PlayButtonSound();
    }

    // OPEN SETTINGS
    public void OpenSettings()
    {
        PlayButtonSound();

        startUIPanel.SetActive(false);

        settingsPanel.SetActive(true);
    }

    // CLOSE SETTINGS
    public void CloseSettings()
    {
        PlayButtonSound();

        settingsPanel.SetActive(false);

        startUIPanel.SetActive(true);
    }

    // MUSIC ON/OFF
    public void ToggleMusic()
    {
        PlayButtonSound();

        AudioManager.Instance.ToggleMusic();
    }

    // EFFECT ON/OFF
    public void ToggleSFX()
    {
        PlayButtonSound();

        AudioManager.Instance.ToggleSFX();
    }

    // QUIT GAME
    public void QuitGame()
    {
        PlayButtonSound();

        Application.Quit();
    }
}