using UnityEngine;

public class StatueMovement : AiMovement
{
    // TODO Add comments
    // Fix bug where statues can obscure each other

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
        if (BeingLookedAt() == false && IsGrounded() == true)
        {
            Move();
        }
    }

    // Return Methods

    private bool BeingLookedAt()
    {
        if (OnScreen() == false)
        {
            return false;
        }

        return true;
    }

    private bool OnScreen()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(transform.position);

        return viewportPoint.z > 0 && viewportPoint.x > 0 && viewportPoint.y > 0 && viewportPoint.y < 1;
    }

    private bool ClearLineOfSight()
    {
        Vector3 directionToStatue = transform.position - Camera.main.transform.position;

        if (Physics.Raycast(Camera.main.transform.position, directionToStatue, out RaycastHit hitInfo))
        {
            if (hitInfo.transform == transform)
            {
                return true;
            }
        }

        return false;
    }

    // Collision Methods

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneTransitionController sceneTransitionController = GameObject.FindFirstObjectByType<SceneTransitionController>();

            sceneTransitionController.ReloadScene();
        }
    }
}
