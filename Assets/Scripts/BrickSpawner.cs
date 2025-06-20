using UnityEngine;

public class BrickSpawner : MonoBehaviour
{   
    public GameObject brickPrefab;
    public int rows = 5;
    public int columns = 3;
    public float spacing = 0.1f;
    public Vector2 startPosition = new Vector2(-2.8f, 4.5f);

    void Start()
    {
    if (brickPrefab == null)
    {
        Debug.LogError("brickPrefab is not assigned in the Inspector!");
        return;
    }

    Vector2 brickSize = brickPrefab.GetComponent<SpriteRenderer>().bounds.size;

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < columns; col++)
        {
            Vector2 position = new Vector2(
                startPosition.x + col * (brickSize.x + spacing),
                startPosition.y + row * (brickSize.y + spacing)
            );

            Instantiate(brickPrefab, position, Quaternion.identity);
        }
    }
    }

}
