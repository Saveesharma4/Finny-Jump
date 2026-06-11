using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;

    [Header("Gameplay")]
    [SerializeField] private PipeSpawner pipeSpawner;

    private int score;

    public bool GameStarted { get; private set; }
    public bool GameOverState { get; private set; }

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

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Time.timeScale = 1;

        GameStarted = false;
        GameOverState = false;

        score = 0;

        scoreText.text = "0";

        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        if (GameStarted)
            return;

        GameStarted = true;

        startPanel.SetActive(false);

        pipeSpawner.BeginSpawning();

        AudioManager.Instance.PlayBackgroundMusic();
    }

    public void AddScore(int amount)
    {
        if (GameOverState)
            return;

        score += amount;

        scoreText.text = score.ToString();

        AudioManager.Instance.PlayScoreSound();
    }

    public void GameOver()
    {
        if (GameOverState)
            return;

        GameOverState = true;

        AudioManager.Instance.StopBackgroundMusic();

        AudioManager.Instance.PlayGameOverSound();

        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}