using UnityEngine;

public class StatueMovement : AiMovement
{
    // TODO Add comments

    // Methods

    protected override void Update()
    {
        base.Update();

        if (BeingLookedAt() == false)
        {
            Turn(ai.destination);
        }
    }

    protected void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        if (BeingLookedAt() == false && IsGrounded() == true && PlayerHasTreasure() == true)
        {
            Move();
        }
    }

    // Return Methods

    private bool BeingLookedAt()
    {
        return OnScreen();
    }

    private bool OnScreen()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        return viewportPoint.z > 0 && viewportPoint.x > 0 && viewportPoint.y > 0 && viewportPoint.y < 1;
    }

    // Collision Methods

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && PlayerHasTreasure() == true)
        {
            SceneTransitionController sceneTransitionController = GameObject.FindFirstObjectByType<SceneTransitionController>();

            sceneTransitionController.ReloadScene();
        }
    }
}
