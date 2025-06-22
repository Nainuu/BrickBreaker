using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public int score = 0;
    public int scorePerBrick = 10;
    public int bricksDestroyed = 0;
    [SerializeField] private GameObject youWonPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text scoreFinalText;

    public void LiveScore(int bricksDestroyed)
    {
        score = bricksDestroyed * scorePerBrick;
        scoreText.text = "Score " + score.ToString();
    }
    private void Start()
    {
        // Initialize score text
        scoreText.text = "Score: " + score.ToString();
        youWonPanel.SetActive(false);
    }
    public void playerWon(int bricksDestroyed)
    {
        Time.timeScale = 0f;
        // Debug.Log("All bricks destroyed! You win!");
        youWonPanel.SetActive(true);
        score = bricksDestroyed * scorePerBrick;
        scoreFinalText.text = "Final Score: " + score.ToString();
        bricksDestroyed = 0; // Reset bricks destroyed for next game
    }
    public void resetScore()
    {
        score = 0;
        bricksDestroyed = 0;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score reset to: " + score);
        Brick.bricksDestroyed = 0;
    }
}
