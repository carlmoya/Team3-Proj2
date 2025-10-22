using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour
{
    // TODO Simplify

    // Fields

    public Transform shootPoint;

    private PlayerGrab playerGrab;

    private AudioSource audioSource;

    // Methods

    private void Start()
    {
        playerGrab = FindFirstObjectByType<PlayerGrab>();

        audioSource = GetComponent<AudioSource>();
    }

    // Collision Methods

    private void OnCollisionEnter(Collision collision)
    {
        // Check if other object is a cannon ball
        if (collision.gameObject.TryGetComponent(out CannonBall cannonBall))
        {
            // Stop the player from holding the cannon ball
            playerGrab.LetGoOfObject(cannonBall.transform.GetComponent<Rigidbody>());

            // Move the cannon ball to the shoot point
            cannonBall.transform.SetPositionAndRotation(shootPoint.position, shootPoint.rotation);

            // Fire the cannon ball
            cannonBall.Fire();

            AudioClip clip = audioSource.clip;

            audioSource.PlayOneShot(clip);

            GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
