using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health = 3;

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") )
        {
            Debug.Log("Brick hit!");
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
