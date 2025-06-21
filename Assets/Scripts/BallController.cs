using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject WelcomePanel;
    // [SerializeField] private float launchForce = 1000f;
    [SerializeField] private float maxSpeed = 20f;

    private Rigidbody2D rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            LaunchBall();
        }
    }

    void FixedUpdate()
    {
        if (!isLaunched) return;

        Vector2 velocity = rb.linearVelocity;

        velocity = velocity.normalized * maxSpeed;

        // Prevent horizontal trap (angle too flat)
        float angle = Vector2.Angle(velocity, Vector2.up);
        if (Mathf.Abs(velocity.y) < 0.2f || Mathf.Abs(velocity.x) < 0.2f)
        {
            float fixedX = 0.5f; 
            float fixedY = 0.5f;

            velocity = new Vector2(fixedX, fixedY).normalized * maxSpeed;;
        }

        rb.linearVelocity = velocity;
    }

    void LaunchBall()
    {
        Vector2 launchDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb.linearVelocity = launchDirection * maxSpeed;

        isLaunched = true;

        FindFirstObjectByType<AudioManager>()?.Play("hitPaddle");
        if (WelcomePanel != null)
            WelcomePanel.SetActive(false);
    }
}
