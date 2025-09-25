using System.Linq;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    // Fields

    public float maxSpeed = 12f;
    public float jumpForce = 12f;

    protected Rigidbody rb;
    protected Collider col;

    // Methods

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    protected virtual void Update()
    {
        SetPhysicsMaterial();
    }

    protected void SetPhysicsMaterial() // Used so that the collider will stick to floors but not to walls
    {
        col.material.staticFriction = IsGrounded() ? 0.6f : 0f; // 0.6f is the default value
        col.material.dynamicFriction = IsGrounded() ? 0.6f : 0f; // 0.6f is the default value
        col.material.frictionCombine = IsGrounded() ? PhysicsMaterialCombine.Average : PhysicsMaterialCombine.Minimum;
    }

    protected void Move()
    {
        float acceleration = 25f;

        // Get desired horizontal velocity
        Vector3 targetVelocity = MovementDirection() * maxSpeed;

        // Project horizontal velocity onto ground to make non-level travel possible
        Vector3 projectedTargetVelocity = Vector3.ProjectOnPlane(targetVelocity, GroundNormal());

        // Inherit the horizontal velocity of any rigidbody below
        if (IsGrounded() == true) { projectedTargetVelocity += new Vector3(FloorVelocity().x, 0f, FloorVelocity().z); }

        // Get the difference from the target velocity and the current velocity
        Vector3 velocityDelta = projectedTargetVelocity - rb.linearVelocity; // Used to avoid exponential acceleration

        // Keep existing vertical velocity
        velocityDelta.y = 0f;

        // Add force to rigidbody
        rb.AddForce(velocityDelta * acceleration, ForceMode.Acceleration);
    }

    protected void Jump()
    {
        if (IsGrounded() == true) { rb.linearVelocity = new Vector3(rb.linearVelocity.z, jumpForce, rb.linearVelocity.z); }
    }

    // Return Methods

    protected abstract Vector3 MovementDirection();

    protected bool CheckCollisionAt(Vector3 position)
    {
        return Physics.OverlapSphere(position, 0.1f).Any(collider => collider != col);
    }

    protected Collider[] ReturnCollidersAt(Vector3 position)
    {
        return Physics.OverlapSphere(position, 0.1f).Where(collider => collider != col).ToArray();
    }

    protected Vector3 ColliderTop()
    {
        return new Vector3(transform.position.x, col.bounds.max.y, transform.position.z);
    }

    protected Vector3 ColliderBottom()
    {
        return new Vector3(transform.position.x, col.bounds.min.y, transform.position.z);
    }

    protected bool IsGrounded()
    {
        return CheckCollisionAt(ColliderBottom());
    }

    protected Vector3 GroundNormal()
    {
        return Physics.Raycast(ColliderBottom(), Vector3.down, out RaycastHit hitInfo) ? hitInfo.normal : Vector3.up;
    }

    protected Vector3 FloorVelocity()
    {
        Collider floorCollider = ReturnCollidersAt(ColliderBottom())
            .FirstOrDefault(collider => collider != col && collider.attachedRigidbody != null);

        return floorCollider?.attachedRigidbody?.linearVelocity ?? Vector3.zero;
    }
}
