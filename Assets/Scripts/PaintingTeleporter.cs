using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaintingTeleporter : MonoBehaviour
{
    // TODO Add comments
    // TODO Check bounds of other collider before teleporting

    // Fields

    public Transform paintingPair;

    private PlayerLook playerLook;
    private PlayerGrab playerGrab;
    private PaintingTeleporter destinationPainting;

    private HashSet<Rigidbody> ignoredObjects = new HashSet<Rigidbody>();

    // Methods

    private void Start()
    {
        playerLook = FindFirstObjectByType<PlayerLook>();
        playerGrab = FindFirstObjectByType<PlayerGrab>();

        destinationPainting = paintingPair.GetComponent<PaintingTeleporter>();
    }

    // Trigger Methods

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has a rigid body and it has not been recently teleported
        if (other.transform.root.TryGetComponent(out Rigidbody targetRb) && ignoredObjects.Contains(targetRb) == false)
        {
            destinationPainting.IgnoreObject(targetRb);

            // If the player is holding the target object, make them let go
            playerGrab.LetGoOfObject(targetRb);

            Quaternion exitDirection = Quaternion.FromToRotation(playerLook.transform.position, paintingPair.transform.right);

            // Teleport the target object
            targetRb.position = TeleportDestination();

            // Rotate the target object's velocity to match the destination painting's direction
            targetRb.linearVelocity = paintingPair.transform.right * (targetRb.linearVelocity.magnitude * -1f);

            if (targetRb.CompareTag("Player"))
            {
                playerLook.SetLookDirection(exitDirection);
            }
        }
    }

    // Coroutines

    public void IgnoreObject(Rigidbody rb)
    {
        if (ignoredObjects.Add(rb))
        {
            StartCoroutine(RemoveFromIgnoredAfterDelay(rb));
        }
    }

    private IEnumerator RemoveFromIgnoredAfterDelay(Rigidbody rb)
    {
        yield return new WaitForSeconds(1f);
        ignoredObjects.Remove(rb);
    }

    // Return Methods

    private Vector3 TeleportDestination()
    {
        // Return point in front of painting pair
        return paintingPair.position + (paintingPair.right * -1f);
    }
}
