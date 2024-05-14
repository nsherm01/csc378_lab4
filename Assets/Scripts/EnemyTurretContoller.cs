using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : MonoBehaviour
{
    private Transform playerTransform;  // Reference to the player's transform
    public float additionalAngle = 90f; // Additional angle in degrees to rotate after facing the player

    // Gun Variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    public float shootInterval = 3f;    // Time interval between shots
    [SerializeField] private AudioSource fireSound; // Reference to the AudioSource component
    public float shootingRadius;

    void Start()
    {
        // Find the player object by tag ("Player")
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;  // Get the player's transform
        }
        else
        {
            Debug.LogError("Player not found! Make sure to tag your player object with the tag 'Player'.");
        }

        // Start shooting coroutine
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval); // Wait for shootInterval seconds

            // Check if playerTransform is valid and within shooting radius before shooting
            if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= shootingRadius)
            {
                // Instantiate bullet at firePoint position and rotation
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                // Add code here to set any additional properties of the bullet (e.g., damage, speed)
                if (fireSound != null)
                {
                    fireSound.Play(); // Play the assigned audio clip
                }
            }
        }
    }

    void Update()
    {
        // Check if playerTransform is valid
        if (playerTransform != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = playerTransform.position - transform.position;

            // Calculate the rotation needed to look at the player
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Apply the rotation to the enemy's transform
            transform.rotation = targetRotation * Quaternion.Euler(0f, 0f, additionalAngle);
        }
    }
}


