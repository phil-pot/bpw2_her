using UnityEngine;
using UnityEngine.UI;  // To access UI elements
using UnityEngine.SceneManagement;  // To restart the scene
using System.Collections;  // To use IEnumerator

public class BallBounceWithUI : MonoBehaviour
{
    // Bounce speed (adjustable in the Inspector)
    public float bounceSpeed = 10f;

    // Maximum number of bounces before the ball stops (adjustable in the Inspector)
    public int maxBounces = 5;

    // Current bounce count
    private int bounceCount = 0;

    // Rigidbody component of the ball
    private Rigidbody rb;

    // UI Text to display remaining bounces (assign in the Inspector)
    public Text bounceCounterText;

    // UI Text to display the game over message (assign in the Inspector)
    public Text gameOverText;

    void Start()
    {
        // Get the Rigidbody component of the ball
        rb = GetComponent<Rigidbody>();

        // Initialize the UI elements
        if (bounceCounterText != null)
        {
            bounceCounterText.text = "Bounces Left: " + (maxBounces - bounceCount);
        }

        if (gameOverText != null)
        {
            gameOverText.enabled = false; // Hide the game over message initially
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rb != null && bounceCount < maxBounces)
        {
            // Get the velocity before the bounce
            Vector3 currentVelocity = rb.velocity;

            // Reflect the velocity based on the normal of the collision
            Vector3 bounceDirection = Vector3.Reflect(currentVelocity, collision.contacts[0].normal).normalized;

            // Ensure the Y component of the bounce direction is zero to lock the movement on the XZ plane
            bounceDirection.y = 0f;

            // Apply the bounce force with the specified speed only on the X and Z axes
            rb.velocity = bounceDirection * bounceSpeed;

            // Increment the bounce count
            bounceCount++;

            // Update the bounce counter UI
            if (bounceCounterText != null)
            {
                bounceCounterText.text = "Bounces Left: " + (maxBounces - bounceCount);
            }
        }
        else
        {
            // Stop the ball after it reaches the maximum number of bounces
            rb.velocity = Vector3.zero;

            // Trigger game over actions when the bounce limit is reached
            StartCoroutine(GameOverSequence());
        }
    }

    void Update()
    {
        if (rb != null && bounceCount < maxBounces)
        {
            // Continuously lock the Y-axis by setting Y velocity to 0
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
    }

    // Coroutine to display game over text and restart the scene
    IEnumerator GameOverSequence()
    {
        // Show the game over message
        if (gameOverText != null)
        {
            gameOverText.enabled = true;
            gameOverText.text = "Game Over! Restarting in 5 seconds...";
        }

        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
