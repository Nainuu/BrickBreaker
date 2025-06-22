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
            if (lives > 0)
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.linearVelocity = Vector2.zero;

                // Move the ball to a resting position (above the paddle)
                collision.gameObject.transform.position = new Vector2(0f, -3f); // You can adjust Y if needed

                // Tell the ball to wait for space key
                FindFirstObjectByType<BallController>()?.PrepareForRelaunch();
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
        scoreCalculator.resetScore();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        FinalScore.text = "Final Score: " + scoreCalculator.score.ToString();
    }
}
