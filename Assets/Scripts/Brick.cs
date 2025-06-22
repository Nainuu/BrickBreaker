using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Brick : MonoBehaviour

{    
    public static int bricksDestroyed = 0;
    [SerializeField] private int health = 2;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject GameHitPrefab;

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindFirstObjectByType<AudioManager>().Play("hit");
            health--;
            if (health <= 0)
            {
                if (GameHitPrefab == null)
                {
                    Debug.LogWarning("GameHitPrefab is not assigned in the Brick script.");
                } else
                {
                    Instantiate(GameHitPrefab, transform.position, Quaternion.identity);
                }

                FindFirstObjectByType<AudioManager>().Play("destroy");
                bricksDestroyed++;
                ScoreCalculator scoreCalculator = FindFirstObjectByType<ScoreCalculator>();
                scoreCalculator.LiveScore(bricksDestroyed);
                // Debug.Log("Brick destroyed! Total bricks destroyed: " + bricksDestroyed);
                if (BrickSpawner.totalBricks == bricksDestroyed)
                {
                    scoreCalculator.playerWon(bricksDestroyed);
                    scoreCalculator.resetScore();
                    bricksDestroyed = 0; // Reset bricks destroyed for next game
                }
                Destroy(gameObject);


            }
        }
    }
}
