using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public int startLives = 3;
    public int score = 0;
    public static UIManager Instance { get; private set; }
    public GameObject gameOverPanel;

    private int lives;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        lives = startLives;
        UpdateScoreUI();
        UpdateLivesUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetLives(int newLives)
    {
        lives = newLives;
        UpdateLivesUI();
    }

    public void LoseLife(int amount)
    {
        lives = Mathf.Max(0, lives - amount);
        UpdateLivesUI();

        if (lives == 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}