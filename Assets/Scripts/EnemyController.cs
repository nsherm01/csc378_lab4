using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public float amplitude = 1.0f;      // Amplitude of the oscillation
    public float frequency = 1.0f;      // Frequency of the oscillation

    private Vector3 startPos;           // Starting position of the object

    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource component
    [SerializeField] private AudioClip hitSoundClip; // AudioClip for hit sound
    [SerializeField] private AudioClip deathSoundClip; // AudioClip for death sound
    public HealthManager healthManager; // reference to the HealthManager

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

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PBullet"))
        {
            healthManager.TakeDamage(10); // decrease health by 10
            Destroy(other.gameObject); // Destroy the bullet

            if (healthManager.curHealth <= 0) // If the enemy's health is less than or equal to 0
            {
                Debug.Log("Enemy Destroyed");
                if (deathSoundClip != null) // death sound
                {
                    Debug.Log("sound");
                    PlaySound(deathSoundClip); // Play the assigned audio clip
                    StartCoroutine(DestroyAfterSound(deathSoundClip.length));
                }
                //Destroy(gameObject);
            }

            else if (hitSoundClip != null) // If enemy still alive
            {
                PlaySound(hitSoundClip); // Play the assigned audio clip
            }

        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip; // Assign the audio clip to the AudioSource
            audioSource.Play(); // Play the assigned audio clip
        }
    }

    private IEnumerator DestroyAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the length of the death sound
        Destroy(gameObject); // Destroy the object after the sound finishes playing
    }
}

