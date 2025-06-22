using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject WelcomePanel;
    // [SerializeField] private float launchForce = 1000f;
    [SerializeField] private float maxSpeed = 20f;
    // private bool waitingForRelaunch = false;

    private Rigidbody2D rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WelcomePanel.SetActive(true);
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
        if (Mathf.Abs(velocity.y) < 0.2f)
        {
            // Too horizontal — force vertical correction
            float correctedX = Mathf.Clamp(velocity.x, -0.7f, 0.7f); // maintain some direction
            velocity = new Vector2(correctedX, 1f).normalized * maxSpeed;
        }
        else if (Mathf.Abs(velocity.x) < 0.2f)
        {
            // Too vertical — add slight sideways motion
            float randomX = Random.Range(-0.5f, 0.5f);
            velocity = new Vector2(randomX, velocity.y).normalized * maxSpeed;
        }

        rb.linearVelocity = velocity;
    }

    public void LaunchBall()
    {
        Vector2 launchDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb.linearVelocity = launchDirection * maxSpeed;

        isLaunched = true;

        FindFirstObjectByType<AudioManager>()?.Play("hitPaddle");
        if (WelcomePanel != null)
            WelcomePanel.SetActive(false);
    }

    public void PrepareForRelaunch()
    {
        isLaunched = false;
        // waitingForRelaunch = true;
    }

}
