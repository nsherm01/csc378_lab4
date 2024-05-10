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
    [SerializeField] private Transform leftPupil;
    [SerializeField] private Transform rightPupil;
    private Vector3 leftPupilRestingPos;
    private Vector3 rightPupilRestingPos;
    [SerializeField] private float maxTranslationDistance = 0.1f;
    [SerializeField] private float maxRadius = 1.5f;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Store the resting positions of the pupils
        leftPupilRestingPos = leftPupil.position;
        rightPupilRestingPos = rightPupil.position;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
        UpdatePupils();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void UpdatePupils()
    {
        if (Camera.main != null)
        {
            // Get mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Calculate target positions for the pupils based on mouse position and player movement
            Vector3 leftTargetPos = leftPupilRestingPos + Vector3.ClampMagnitude(mousePosition - leftPupilRestingPos, maxTranslationDistance);
            Vector3 rightTargetPos = rightPupilRestingPos + Vector3.ClampMagnitude(mousePosition - rightPupilRestingPos, maxTranslationDistance);

            // Limit the target positions to stay within the maxRadius from initial state
            leftTargetPos = leftPupilRestingPos + Vector3.ClampMagnitude(leftTargetPos - leftPupilRestingPos, maxRadius);
            rightTargetPos = rightPupilRestingPos + Vector3.ClampMagnitude(rightTargetPos - rightPupilRestingPos, maxRadius);

            // Update pupils' positions
            leftPupil.position = leftTargetPos;
            rightPupil.position = rightTargetPos;
        }
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
