using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }
}
