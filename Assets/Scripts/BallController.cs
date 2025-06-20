using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float launchForce = 1000f;
    [SerializeField] private float maxSpeed = 20f;

    private Rigidbody2D rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void FixedUpdate()
    {
        // Clamp speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void LaunchBall()
    {
        if (!isLaunched)
        {
            Vector2 launchDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
            rb.AddForce(launchDirection * launchForce);
            isLaunched = true;
        }
    }
}
