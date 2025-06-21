using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class BaseController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private string startSceneName = "SampleScene";
    private bool isGameOver = false;
    public int lives = 2;
    [SerializeField] private TMP_Text FinalScore;
    private ScoreCalculator scoreCalculator;
    // [SerializeField] private AudioManager audioManager;

    void Start()
    {
        gameOverPanel.SetActive(false);
        // audioManager = FindFirstObjectByType<AudioManager>();
        scoreCalculator = FindFirstObjectByType<ScoreCalculator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            lives--;
            FindFirstObjectByType<AudioManager>().Play("die");
            // audioManager.Play("playerDeath");
            if (lives == 0)
            {
                Debug.Log("Lives left: " + lives);
                // Reset ball position or any other logic for losing a life
                collision.gameObject.transform.position = new Vector2(0, -3); // Example reset position
            }
            else
            {
                GameOver();
            }

        }
    }
    public void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            GoToStartScreen();
        }
    }
    public void GoToStartScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(startSceneName);
        scoreCalculator.bricksDestroyed = 0;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        FinalScore.text = "Final Score: " + scoreCalculator.score.ToString();
        scoreCalculator.bricksDestroyed = 0; // Reset bricks destroyed for next game
    }
}
