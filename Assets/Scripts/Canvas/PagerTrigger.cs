using UnityEngine;

public class PagerTrigger : MonoBehaviour
{
    // Fields

    public string message;

    private Pager pager;

    // Methods

    private void Start()
    {
        // Get reference to pager
        pager = FindFirstObjectByType<Pager>();
    }

    // Trigger Methods

    private void OnTriggerEnter(Collider other)
    {
        // If the other object is the player
        if (other.CompareTag("Player"))
        {
            // Add the message to the pager's message queue
            pager.messageQueue.Add(message);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the other object is the player
        if (other.CompareTag("Player"))
        {
            // Remove the message from the pager's message queue
            pager.messageQueue.Remove(message);
        }
    }
}
