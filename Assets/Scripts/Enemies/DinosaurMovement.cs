using UnityEngine;

public class DinosaurMovement : AiMovement
{
    // Methods

    protected override void Update()
    {
        base.Update();

        Turn(ai.destination);
    }

    protected void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        if (base.IsGrounded() == true)
        {
            base.Move();
        }
    }

    // Collision Methods

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<HealthBase>().Modify(-1);
        }
    }
}
