using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Gun Variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Vector2 lookDirection;

    private void Update()
    {
        // Get the mouse position
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Calculate the angle
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        // Rotate the turret
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
