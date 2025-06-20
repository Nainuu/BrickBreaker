using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Brick : MonoBehaviour

{    public static int bricksDestroyed = 0;
    [SerializeField] private int health = 2;
    [SerializeField] private TMP_Text scoreText;

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindFirstObjectByType<AudioManager>().Play("hit");
            health--;
            if (health <= 0)
            {
                FindFirstObjectByType<AudioManager>().Play("destroy");
                bricksDestroyed++;
                ScoreCalculator scoreCalculator = FindFirstObjectByType<ScoreCalculator>();
                scoreCalculator.LiveScore(bricksDestroyed);
                Debug.Log("Brick destroyed! Total bricks destroyed: " + bricksDestroyed);
                if (BrickSpawner.totalBricks == bricksDestroyed)
                {
                    scoreCalculator.playerWon(bricksDestroyed);
                }
                Destroy(gameObject);


            }
        }
    }
}
