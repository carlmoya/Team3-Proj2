using UnityEngine;

// Project L.I.F.E

public class PlayerMovement : BaseMovement
{
    // Fields

    [Header("\nNon-Inherited Settings")]
    [Space(15)]
    public Transform mainCamera;

    private PlayerLook playerlook;

    // Methods

    protected override void Start()
    {
        base.Start();

        playerlook = mainCamera.GetComponent<PlayerLook>();
    }

    protected void Update()
    {
        CheckJump();
    }

    protected void CheckJump()
    {
        if (Input.GetButton("Jump"))
        {
            base.StartJump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            base.StopJump();
        }
    }

    // Return Methods

    public override bool IsMoving()
    {
        return ClampedInputDirection().magnitude > 0.1f;
    }

    protected override Vector3 MovementDirection()
    {
        return playerlook.FlatCameraRotation() * ClampedInputDirection();
    }
    protected Vector3 ClampedInputDirection()
    {
        return Vector3.ClampMagnitude(InputDirection(), 1f);
    }

    protected Vector3 InputDirection()
    {
        return new Vector3(XInput(), 0f, ZInput());
    }

    protected float XInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    protected float ZInput()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
