using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    // Public fields to be set from the Inspector
    public GameObject targetObject;  // The object to check for collision
    public AudioClip soundClip;      // The sound clip to play
    private bool hasPlayed = false;  // To ensure the sound is played only once

    private AudioSource audioSource; // The AudioSource component for playing the sound

    void Start()
    {
        // Add an AudioSource component to the GameObject this script is attached to
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the target object and if the sound hasn't played yet
        if (collision.gameObject == targetObject && !hasPlayed)
        {
            // Play the sound clip
            audioSource.Play();

            // Mark that the sound has been played so it doesn't play again
            hasPlayed = true;
        }
    }
}
