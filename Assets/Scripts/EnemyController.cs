using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public float amplitude = 1.0f;      // Amplitude of the oscillation
    public float frequency = 1.0f;      // Frequency of the oscillation

    private Vector3 startPos;           // Starting position of the object

    void Start()
    {
        startPos = transform.position;  // Store the starting position of the object
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

