using System.Linq;
using UnityEngine;

// Project L.I.F.E

public abstract class BaseMovement : MonoBehaviour
{
    // Fields

    [Header("Inherited Settings")]
    [Space(15)]
    public float moveForce = 12f;
    public float jumpForce = 12f;
    public float airAcceleration = 5f;
    public float groundAcceleration = 15f;

    protected Rigidbody rb;
    protected Collider col;

    // Methods

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        rb.AddForce(FlatVelocityDelta() * Acceleration(), ForceMode.Acceleration);
    }

    protected virtual void StartJump()
    {
        if (IsGrounded() == true)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    protected virtual void StopJump()
    {
        if (rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f, rb.linearVelocity.z);
        }
    }

    // Abstract Methods

    protected abstract Vector3 MovementDirection();

    // Return Methods | Velocity

    public virtual bool IsMoving()
    {
        return rb.linearVelocity.magnitude > 0.1f ? true : false;
    }

    protected float Acceleration()
    {
        return IsGrounded() == true ? groundAcceleration : airAcceleration;
    }

    protected Vector3 FlatVelocityDelta()
    {
        return new Vector3(VelocityDelta().x, 0f, VelocityDelta().z);
    }

    protected Vector3 VelocityDelta()
    {
        return RelativeTargetVelocity() - rb.linearVelocity;
    }

    protected Vector3 RelativeTargetVelocity()
    {
        return IsGrounded() == true ? TargetVelocity() + new Vector3(FloorVelocity().x, 0f, FloorVelocity().z) : TargetVelocity();
    }

    protected Vector3 TargetVelocity()
    {
        return MovementDirection() * moveForce;
    }

    protected Vector3 FloorVelocity()
    {
        Collider floorCollider = ReturnCollidersAt(ColliderBottom())
            .FirstOrDefault(floorCol => floorCol.attachedRigidbody != null);

        return floorCollider?.attachedRigidbody?.linearVelocity ?? Vector3.zero;
    }

    // Return Methods | Collision

    public bool IsGrounded()
    {
        return CheckCollisionAt(ColliderBottom()) ? true : false;
    }

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
}
