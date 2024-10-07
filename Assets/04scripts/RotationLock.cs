using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    // Store the initial rotation to lock the object to its current rotation
    private Quaternion lockedRotation;

    void Start()
    {
        // Get and store the object's current rotation at the start
        lockedRotation = transform.rotation;
    }

    void Update()
    {
        // Maintain the object's position, but lock its rotation to the initial value
        transform.rotation = lockedRotation;
    }
}
