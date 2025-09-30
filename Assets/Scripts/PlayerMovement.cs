using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MovementBase
{
    // Fields

    protected float standingHeight;
    protected float crouchingHeight;

    protected Coroutine heightAnimation = null;

    // Methods

    protected override void Start()
    {
        base.Start();

        standingHeight = transform.localScale.y;
        crouchingHeight = standingHeight / 2f;
    }

    protected override void Update()
    {
        base.Update();

        HandleJump();
        HandleCrouch();
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

    protected void HandleCrouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch();
        }

        if (Input.GetButtonUp("Crouch"))
        {
            UnCrouch();
        }
    }

    protected void Crouch()
    {
        if (heightAnimation != null) { StopCoroutine(heightAnimation); }

        heightAnimation = StartCoroutine(HeightAnimation(crouchingHeight));
    }

    protected void UnCrouch()
    {
        if (heightAnimation != null) { StopCoroutine(heightAnimation); }

        heightAnimation = StartCoroutine(HeightAnimation(standingHeight, () => CheckCollisionAt(ColliderTop()) == false));
    }

    // Coroutines

    protected IEnumerator HeightAnimation(float targetHeight, Func<bool> canProgress = null) // Used for crouching & uncrouching
    {
        float startHeight = transform.localScale.y;
        float heightDelta = Mathf.Abs(targetHeight - startHeight);

        // Customize duration
        float speed = 4f;
        float duration = heightDelta / speed;

        // Track the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < duration;)
        {
            if (canProgress == null || canProgress() == true) // If condition is null or met
            {
                elapsedTime += Time.deltaTime; // Progress animation
            }

            float time = elapsedTime / duration; // Normalize elapsed time

            // Interpolate over time
            float currentHeight = Mathf.Lerp(startHeight, targetHeight, time);

            // Apply animation
            transform.localScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z);

            yield return null; // Wait for next frame
        }

        // Ensure finished animation state
        transform.localScale = new Vector3(transform.localScale.x, targetHeight, transform.localScale.z);
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
