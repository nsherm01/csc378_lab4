using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] private AudioSource sounds; // Reference to the AudioSource component
    [SerializeField] private AudioClip hitSound;
    public HealthManager healthManager; // reference to the HealthManager
    [SerializeField] private AudioClip heartSound;
    public float heartHealAmount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
        // UpdatePupils();
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
                sounds.PlayOneShot(hitSound); // Play the assigned audio clip
            }
            Destroy(other.gameObject);

            //Lower the health of the player
            healthManager.TakeDamage(10); // decrease health by 10
        }
        else if (other.CompareTag("Heart"))
        {
            if (heartSound != null)
            {
                sounds.PlayOneShot(heartSound); // Play the assigned audio clip for heart pickup
            }
            healthManager.Heal(heartHealAmount); // Increase health by 10
            Destroy(other.gameObject); // Destroy the heart object  
        }
    }

}
