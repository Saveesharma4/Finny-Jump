using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Music")]
    [SerializeField] private AudioClip backgroundMusic;

    [Header("UI Sounds")]
    [SerializeField] private AudioClip buttonClickSound;

    [Header("Game Sounds")]
    [SerializeField] private AudioClip flapSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic == null)
            return;

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    public void PlayButtonSound()
    {
        if (buttonClickSound != null)
        {
            sfxSource.PlayOneShot(buttonClickSound);
        }
    }

    public void PlayFlapSound()
    {
        if (flapSound != null)
        {
            sfxSource.PlayOneShot(flapSound);
        }
    }

    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            sfxSource.PlayOneShot(hitSound);
        }
    }

    public void PlayScoreSound()
    {
        if (scoreSound != null)
        {
            sfxSource.PlayOneShot(scoreSound);
        }
    }

    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            sfxSource.PlayOneShot(gameOverSound);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
}