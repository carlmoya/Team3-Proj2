using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // Fields

    private float maxSpeed = 6f;

    private float grabDistance;
    private Rigidbody grabbedObjectRb = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pickup();
        }

        if (Input.GetMouseButtonUp(0) && grabbedObjectRb != null)
        {
            Drop();
        }

        if (grabbedObjectRb != null)
        {
            Debug.DrawLine(grabbedObjectRb.position, GrabPoint(), Color.red);
        }

        // TODO Replace mouse buttons with named buttons
    }

    private void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        if (grabbedObjectRb != null) { MoveGrabbedObject(); }
    }

    private void Pickup()
    {
        if (Target() != null)
        {
            grabbedObjectRb = Target().GetComponent<Rigidbody>();

            grabbedObjectRb.freezeRotation = true;

            grabDistance = Vector3.Distance(transform.position, grabbedObjectRb.position);
        }
    }

    private void Drop()
    {
        grabbedObjectRb.freezeRotation = false;

        grabbedObjectRb = null;
    }

    private void MoveGrabbedObject()
    {
        float acceleration = 25f;

        Vector3 moveDirection = GrabPoint() - grabbedObjectRb.position;

        Vector3 targetVelocity = moveDirection * maxSpeed;

        Vector3 velocityDelta = targetVelocity - grabbedObjectRb.linearVelocity;

        grabbedObjectRb.AddForce(velocityDelta * acceleration, ForceMode.Acceleration);

        // TODO scale maxSpeed with Rigidbody mass
    }

    // Return Methods

    private Transform Target()
    {
        // Shoot ray & store hit info
        if (Physics.Raycast(Ray(), out RaycastHit hitInfo))
        {
            // Check if hit object has a rigidbody
            if (hitInfo.transform.GetComponent<Rigidbody>() != null)
            {
                return hitInfo.transform;
            }
        }

        return null;
    }

    private Vector3 GrabPoint()
    {
        if (Physics.Raycast(Ray(), out RaycastHit hitInfo, grabDistance))
        {
            if (hitInfo.transform != grabbedObjectRb.transform)
            {
                return hitInfo.point;
            }
        }

        return Camera.main.transform.position + (Camera.main.transform.forward * grabDistance);
    }

    private Ray Ray()
    {
        // Return ray from the center of the screen
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
    }

    // TODO Break connection if there is an obstruction in the way

    // TODO Bring grab distance closer or further with the scrollwheel
}