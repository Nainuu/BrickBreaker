using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public int score = 0;
    public int scorePerBrick = 10;
    [SerializeField] private GameObject youWonPanel;
    [SerializeField] private TMP_Text scoreText;

    public void LiveScore(int bricksDestroyed)
    {
        score = bricksDestroyed * scorePerBrick;
        scoreText.text = score.ToString();
        Debug.Log("Current Score: " + score);
    }
    private void Start()
    {
        // Initialize score text
        scoreText.text = "Score: " + score.ToString();
        youWonPanel.SetActive(false);
    }
    public void playerWon()
    {
        Time.timeScale = 0f;
        Debug.Log("All bricks destroyed! You win!");
        youWonPanel.SetActive(true);
    }
}
