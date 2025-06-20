using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    private float moveInput;
    [SerializeField] private float minX = -2.8f;
    [SerializeField] private float maxX = 2.8f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x + moveInput * speed * Time.fixedDeltaTime, minX, maxX);
        rb.MovePosition(pos);
    }
}