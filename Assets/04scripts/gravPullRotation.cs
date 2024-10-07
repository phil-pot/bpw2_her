using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravPullRotation : MonoBehaviour
{
    // Speed of movement (adjustable in the Inspector)
    public float moveSpeed = 5f;
    public float pullForce = 10f;

    // Reference to the ball
    public Transform ball;
    public Rigidbody ballRb;

    private Transform closestTarget;

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Find the closest target with the "target" tag
            closestTarget = FindClosestTarget();

            if (closestTarget != null)
            {
                // Calculate direction to the closest target
                Vector3 targetDir = closestTarget.position - ball.position;

                // Apply force to the ball towards the closest target
                ballRb.AddForce(targetDir.normalized * pullForce, ForceMode.Impulse);
            }
        }
    }

    // Method to find the closest target with the "target" tag
    Transform FindClosestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");  // Find all objects with the "target" tag
        Transform closest = null;
        float minDistance = Mathf.Infinity;  // Set an initially large distance

        // Loop through each target and calculate its distance to the ball
        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(ball.position, target.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = target.transform;
            }
        }

        return closest;  // Return the closest target found
    }
}
