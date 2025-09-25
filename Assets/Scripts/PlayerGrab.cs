using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // Fields

    // Vector3 grab point

    // Vector3 grabbed object

    // Methods

    private void Update()
    {
        // If player presses pickup button
            // Pickup();

        // If player presses drop button
            // Drop();
    }

    private void Pickup()
    {
        // If Target is not null
            // Set grab point at target location
            // Assign target game object to grabbedObject
    }

    private void MoveGrabbedObject()
    {
        // Get desired force to add based on object mass
        // Add force to move grabbed object closer to grab point
    }

    // Return Methods

    private void Target()
    {
        // Return whatever grabbable object the player is looking at
        // Return null if not looking at grabbable object
    }
}
