using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRotation : MonoBehaviour
{
    // Rotation speed 
    public float rotationSpeed = 100f;

    void Update()
    {
        // 0 is for left click, 1 for right click, 2 for middle click
        
        if (Input.GetMouseButton(0)) 
        {
            // rotate around x axis
            // rechts !! !
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetMouseButton(1)) 
        {
            // links !!
            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}