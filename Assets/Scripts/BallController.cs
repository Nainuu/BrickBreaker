using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private float launchForce = 1000f;
    [SerializeField] private float maxSpeed = 20f;

    private Rigidbody2D rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        // Launch the ball when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            Debug.Log("Launching Ball");
            LaunchBall();
        }
    }

    void FixedUpdate()
    {
        if (isLaunched)
        {
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
            else
            {
                if (rb.linearVelocity.y < 0.1f && rb.linearVelocity.y > -0.1f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.1f);
                }
            }   
        }
    }

    void LaunchBall()
    {
        Vector2 launchDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb.AddForce(launchDirection * launchForce);
        isLaunched = true;
        WelcomePanel.SetActive(false);
    }
}
