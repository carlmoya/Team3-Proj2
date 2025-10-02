using UnityEngine;

public class PlayerMovement : MovementBase
{
    // Methods

    protected override void Update()
    {
        base.Update();

        HandleJump();
    }

    protected void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        Move();
    }

    protected void HandleJump()
    {
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }

    // Return Methods

    protected override Vector3 MovementDirection()
    {
        // Get horizontal & vertical movement input
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Combine horizontal & vertical movement input
        Vector3 inputDirection = new Vector3(xInput, 0f, zInput);

        // Prevent player from moving faster diagonally
        Vector3 normalizedInputDirection = Vector3.ClampMagnitude(inputDirection, 1f);

        // Rotate input direction by camera's Y rotation
        Vector3 movementDirection = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * normalizedInputDirection;

        return movementDirection;
    }
}
