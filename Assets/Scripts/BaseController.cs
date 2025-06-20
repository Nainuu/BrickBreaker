using UnityEngine;
using UnityEngine.SceneManagement;
public class BaseController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private string startSceneName = "SampleScene";
    private bool isGameOver = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Time.timeScale = 0f;
            isGameOver = true;
            gameOverPanel.SetActive(true);
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
    }
}
