using UnityEngine;

public class BirdController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float swimForce = 4.5f;

    [Header("Rotation")]
    [SerializeField] private float maxUpRotation = 25f;
    [SerializeField] private float maxDownRotation = -60f;
    [SerializeField] private float rotationSpeed = 5f;

    [Header("Bounds")]
    [SerializeField] private float upperLimit = 1.15f;
    [SerializeField] private float lowerLimit = -0.15f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Keep gravity always enabled
        rb.gravityScale = 1.2f;
    }

    private void Update()
    {
        if (GameManager.Instance.GameOverState)
            return;

        HandleInput();
        HandleRotation();
        CheckBounds();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start game on first tap
            if (!GameManager.Instance.GameStarted)
            {
                GameManager.Instance.StartGame();
            }

            // Smooth movement
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                0f
            );

            rb.AddForce(
                Vector2.up * swimForce,
                ForceMode2D.Impulse
            );

            AudioManager.Instance.PlayFlapSound();
        }
    }

    private void HandleRotation()
    {
        float targetRotation = Mathf.Lerp(
            maxDownRotation,
            maxUpRotation,
            (rb.linearVelocity.y + 5f) / 10f
        );

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, targetRotation),
            rotationSpeed * Time.deltaTime
        );
    }

    private void CheckBounds()
    {
        Vector3 viewportPosition =
            Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.y > upperLimit ||
            viewportPosition.y < lowerLimit)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        if (GameManager.Instance.GameOverState)
            return;

        AudioManager.Instance.PlayHitSound();

        GameManager.Instance.GameOver();
    }
}