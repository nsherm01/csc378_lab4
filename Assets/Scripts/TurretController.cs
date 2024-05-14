using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Gun Variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;
    private float firingTimer;
    [SerializeField] private AudioSource fireSound; // Reference to the AudioSource component

    private Vector2 lookDirection;

    // face varaibles
    public GameObject leftEyebrow; // First object to show
    public GameObject rightEyebrow; // Second object to show
    [SerializeField] private float eyebrowRevealTime = 0.5f; // Time to reveal the objects


    private void Update()
    {
        // Get the mouse position
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Calculate the angle
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        // Rotate the turret
        transform.rotation = Quaternion.Euler(0, 0, angle);

        firingTimer -= Time.deltaTime;
    }

    private void OnFire()
    {
        if (firingTimer <= 0)
        {
            Fire();
            firingTimer = fireRate;
        }
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (fireSound != null)
        {
            fireSound.Play(); // Play the assigned audio clip
        }
        StartCoroutine(RevealEyebrows());
    }

    private IEnumerator RevealEyebrows()
    {
        // Show the first object
        leftEyebrow.SetActive(true);

        // Show the second object
        rightEyebrow.SetActive(true);

        // Wait for half a second
        yield return new WaitForSeconds(eyebrowRevealTime);

        // Hide the first object
        leftEyebrow.SetActive(false);

        // Hide the second object
        rightEyebrow.SetActive(false);
    }
}
