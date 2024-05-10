using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] private AudioSource hitSound; // Reference to the AudioSource component
    public HealthManager healthManager; // reference to the HealthManager

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EBullet"))
        {
            if (hitSound != null)
            {
                hitSound.Play(); // Play the assigned audio clip
            }
            Destroy(other.gameObject);

            //Lower the health of the player
            healthManager.TakeDamage(10); // decrease health by 10

        }


    }

}
