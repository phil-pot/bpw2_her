using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    // Movement speed (adjustable in the Inspector)
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Check if the space bar is being held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Move the object along the X and Z axes only (no Y axis movement)
            Vector3 moveDirection = new Vector3(1, 0, 1).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
