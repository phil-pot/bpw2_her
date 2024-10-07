using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceOffWall : MonoBehaviour
{
    // Object to detect for collision (assigned in the Inspector)
    public GameObject objectToBounce;

    // Bounce speed (adjustable in the Inspector)
    public float bounceSpeed = 10f;

    // On collision with the wall
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the specified object
        if (collision.gameObject == objectToBounce)
        {
            // Get the object's Rigidbody component
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Calculate the bounce direction by reflecting the velocity based on the collision normal
                Vector3 bounceDirection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal).normalized;

                // Apply the bounce force with the specified speed
                rb.velocity = bounceDirection * bounceSpeed;
            }
        }
    }
}
