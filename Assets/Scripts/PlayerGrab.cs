using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // Fields

    public float throwForce = 20f;
    public float scrollWheelDistance = 3f;
    public float grabbedObjectSpeedMultiplier = 8f;

    private float grabDistance;
    private Rigidbody grabbedObject = null;

    private RigidbodyConstraints originalContraints;

    // Methods

    private void Update()
    {
        HandlePickup();
        HandleThrow();
        HandleScroll();
    }

    private void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        if (grabbedObject != null)
        {
            MoveGrabbedObject();
        }
    }

    private void HandlePickup()
    {
        if (Input.GetMouseButtonDown(0) && Target() != null)
        {
            // Set the grabbed rigid body to the rigidbody of the target object
            grabbedObject = Target().GetComponent<Rigidbody>();

            // Set the grabbed rigid body to respond to physics
            grabbedObject.isKinematic = false;

            // Store the rotation constraints of the grabbed object
            originalContraints = grabbedObject.constraints;

            // Freeze the rotation of the grabbed object
            grabbedObject.freezeRotation = true;

            // Set the grab distance to the distance between the player & the grabbed object
            grabDistance = Vector3.Distance(transform.position, grabbedObject.position);
        }

        if (Input.GetMouseButtonUp(0))
        {
            LetGo();
        }
    }

    private void HandleThrow()
    {
        if (Input.GetMouseButton(1) && grabbedObject != null)
        {
            // Add force to the rigid body of the grabbed object
            grabbedObject.AddForce(LookDirection().direction * throwForce, ForceMode.VelocityChange);

            LetGo();
        }
    }

    private void LetGo()
    {
        if (grabbedObject != null)
        {
            // Unfreeze the rotation of the grabbed object
            grabbedObject.constraints = originalContraints;

            // Unset the grabbed rigid body
            grabbedObject = null;
        }
    }

    private void HandleScroll()
    {
        // Get scroll wheel axis
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Check for scroll wheel input
        if (Mathf.Abs(scrollInput) > 0.01f)
        {
            // Add scroll wheel input to grab distance
            grabDistance += scrollInput * scrollWheelDistance;

            // Clamp the grab distance to ensure it doesn't become too small or negative
            grabDistance = Mathf.Max(grabDistance, 1f);
        }
    }

    private void MoveGrabbedObject()
    {
        float acceleration = 25f;

        // Get the direction from the grabbed object to the grab point
        Vector3 moveDirection = GrabPoint() - grabbedObject.position;

        // Get the desired velocity of the grabbed object
        Vector3 targetVelocity = moveDirection * grabbedObjectSpeedMultiplier;

        // Get the difference between the grabbed object's target velocity and current velocity
        Vector3 velocityDelta = targetVelocity - grabbedObject.linearVelocity;

        // Add force to the rigidbody of the grabbed object
        grabbedObject.AddForce(velocityDelta * acceleration, ForceMode.Acceleration);
    }

    public void LetGoOfObject(Rigidbody inputObject)
    {
        if (inputObject == grabbedObject)
        {
            LetGo();
        }
    }

    // Return Methods

    public Transform Target()
    {
        // Shoot ray & store hit info
        if (Physics.Raycast(LookDirection(), out RaycastHit hitInfo))
        {
            // Check if hit object has a rigidbody
            if (hitInfo.transform.GetComponent<Rigidbody>() != null) { return hitInfo.transform; }
        }

        return null;
    }

    public bool GrabbingSomething()
    {
        return grabbedObject != null;
    }

    public Vector3 GrabPoint()
    {
        // Shoot ray & store hit info
        if (Physics.Raycast(LookDirection(), out RaycastHit hitInfo, grabDistance))
        {
            // Return the point where the ray hit the environment
            if (hitInfo.transform != grabbedObject.transform) { return hitInfo.point; }
        }

        // Fallback: return point in front of the player
        return LookDirection().origin + (LookDirection().direction * grabDistance);
    }

    public Ray LookDirection()
    {
        // Return the direction that the camera is looking towards
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
    }

    public bool GrabbingTreasure()
    {
        // Return true if the grabbed object is treasure
        return grabbedObject != null && grabbedObject.CompareTag("Treasure");
    }

    public Transform GrabbedObject()
    {
        if (grabbedObject == null)
        {
            return null;
        }

        return grabbedObject.transform;
    }
}