using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pager : MonoBehaviour
{
    [HideInInspector] public List<string> messageQueue;

    private TMP_Text pagerText;
    private Coroutine messageAnimation = null;

    private Vector3 upPosition = new Vector3(-710f, -365f, 0f);
    private Vector3 downPosition = new Vector3(-710f, -700f, 0f);

    private AudioSource audioSource;

    private void Start()
    {
        // Get reference to pager text
        pagerText = GetComponentInChildren<TMP_Text>();

        // Get reference to audio source
        audioSource = GetComponent<AudioSource>();

        // Start position animation
        StartCoroutine(PositionAnimation());
    }

    private void Update()
    {
        CheckMessages();
    }

    private void CheckMessages()
    {
        // If a message is not currently animating
        if (messageAnimation == null)
        {
            // If there is a message in the message queue
            if (messageQueue.Count > 0)
            {
                // Play the message
                messageAnimation = StartCoroutine(MessageAnimation(messageQueue[0]));
            }
        }
    }

    // Coroutines

    private IEnumerator MessageAnimation(string message)
    {
        // Play pager beep sound
        if (audioSource != null) { audioSource.Play(); }

        // For each character in the message
        foreach (char character in message)
        {
            // Add the character to the pager text
            pagerText.text += character;

            // Wait to display the next character
            yield return new WaitForSeconds(0.05f);
        }

        // Wait for the player to read the message
        yield return new WaitForSeconds(3f);

        // Clear the pager text
        pagerText.text = "";

        // Remove the message from the message queue
        messageQueue.Remove(message);

        // Set the message animation to null;
        messageAnimation = null;
    }

    private IEnumerator PositionAnimation()
    {
        while (true) // Runs forever unless stopped
        {
            // If the current location is not the target location
            if (transform.localPosition != TargetPosition())
            {
                // Move the current location towards the target location
                transform.localPosition = Vector3.Lerp(transform.localPosition, TargetPosition(), 0.1f);
            }

            // Wait before trying to move the current location again
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Return Methods

    private Vector3 TargetPosition()
    {
        // Return a target position based on whether a message is animating
        return messageAnimation != null ? upPosition : downPosition;
    }
}
