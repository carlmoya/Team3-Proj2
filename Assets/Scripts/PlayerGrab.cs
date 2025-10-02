using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    // TODO Fix jitter when looking at grabbed object while moving it
    // TODO Add comments

    // Fields

    public float throwForce = 20f;
    public float scrollWheelDistance = 3f;
    public float grabbedObjectMaxSpeed = 8f;

    private float grabDistance;
    private Rigidbody grabbedRigidbody = null;

    private RigidbodyConstraints originalConstraints;

    // Methods

    private void Update()
    {
        HandleInput();

        DrawDebugLine();
    }

    private void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        if (grabbedRigidbody != null) { MoveGrabbedObject(); }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickup();
        }

        if (Input.GetMouseButtonUp(0))
        {
            TryLetGo();
        }

        if (Input.GetMouseButtonDown(1))
        {
            TryThrow();
        }

        HandleScroll();
    }

    private void TryPickup()
    {
        if (Target() != null)
        {
            // Set the grabbed rigid body to the rigidbody of the target object
            grabbedRigidbody = Target().GetComponent<Rigidbody>();

            // Store the rotation constraints of the grabbed object
            originalConstraints = grabbedRigidbody.constraints;

            // Freeze the rotation of the grabbed object
            grabbedRigidbody.freezeRotation = true;

            // Set the grab distance to the distance between the player & the grabbed object
            grabDistance = Vector3.Distance(transform.position, grabbedRigidbody.position);
        }
    }

    private void TryLetGo()
    {
        if (grabbedRigidbody != null)
        {
            // Unfreeze the rotation of the grabbed object
            grabbedRigidbody.constraints = originalConstraints;

            // Unset the grabbed rigid body
            grabbedRigidbody = null;
        }
    }

    private void TryThrow()
    {
        if (grabbedRigidbody != null)
        {
            // Add force to the rigidbody of the grabbed object
            grabbedRigidbody.AddForce(LookDirection().direction * throwForce, ForceMode.VelocityChange);

            TryLetGo();
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
            grabDistance = Mathf.Max(grabDistance + scrollInput * scrollWheelDistance, 1f);
        }
    }

    private void MoveGrabbedObject()
    {
        float acceleration = 25f;

        // Get the direction from the grabbed object to the grab point
        Vector3 moveDirection = GrabPoint() - grabbedRigidbody.position;

        // Get the desired velocity of the grabbed object
        Vector3 targetVelocity = moveDirection * grabbedObjectMaxSpeed;

        // Get the difference between the grabbed object's target velocity and current velocity
        Vector3 velocityDelta = targetVelocity - grabbedRigidbody.linearVelocity;

        // Add force to the rigidbody of the grabbed object
        grabbedRigidbody.AddForce(velocityDelta * acceleration, ForceMode.Acceleration);
    }

    private void DrawDebugLine()
    {
        if (grabbedRigidbody != null) { Debug.DrawLine(grabbedRigidbody.position, GrabPoint(), Color.red); }
    }

    // Return Methods

    private Transform Target()
    {
        // Shoot ray & store hit info
        if (Physics.Raycast(LookDirection(), out RaycastHit hitInfo))
        {
            // Check if hit object has a rigidbody
            if (hitInfo.transform.GetComponent<Rigidbody>() != null) { return hitInfo.transform; }
        }

        return null;
    }

    private Vector3 GrabPoint()
    {
        // Shoot ray & store hit info
        if (Physics.Raycast(LookDirection(), out RaycastHit hitInfo, grabDistance))
        {
            // Return the point where the ray hit the environment
            if (hitInfo.transform != grabbedRigidbody.transform) { return hitInfo.point; }
        }

        // Fallback: return point in front of the player
        return LookDirection().origin + (LookDirection().direction * grabDistance);
    }

    private Ray LookDirection()
    {
        return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
    }

    public bool GrabbingTreasure()
    {
        if (grabbedRigidbody != null)
        {
            if (grabbedRigidbody.transform.CompareTag("Treasure"))
            {
                return true;
            }

            return false;
        }

        return false;
    }
}