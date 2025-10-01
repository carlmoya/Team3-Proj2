using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AiMovement : MovementBase
{
    // TODO Add comments
    // TODO Make agent avoid other nearby agents to prevent agent pile-ups

    // Fields

    public List<string> targetTags = new List<string>();

    protected NavMeshAgent ai;

    // Methods

    protected override void Start()
    {
        base.Start();

        ai = GetComponent<NavMeshAgent>();

        ai.updatePosition = false;
        ai.updateRotation = false;
    }

    protected override void Update()
    {
        base.Update();

        GetDestination();
    }

    protected void Turn(Vector3 target)
    {
        // Avoid turning vertically
        target.y = transform.position.y;

        // Angular speed in radians per second
        float speed = 90f;

        // Determine which direction to rotate towards
        Vector3 targetDirection = target - transform.position;

        // The step size is equal to speed times frame time
        float singleStep = speed * Time.fixedDeltaTime;

        // Get target rotation from target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // Rotate towards the target by one step
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, singleStep));
    }

    protected void GetDestination()
    {
        foreach (string tag in targetTags)
        {
            if (GetNearestTarget(tag, out Transform target))
            {
                ai.SetDestination(target.position);
                return;
            }
        }
    }

    // Return Methods

    protected bool GetNearestTarget(string targetTag, out Transform nearestTarget)
    {
        nearestTarget = Physics.OverlapSphere(transform.position, 20f)
            .Where(collider => collider.CompareTag(targetTag))
            .OrderBy(collider => Vector3.Distance(transform.position, collider.transform.position))
            .FirstOrDefault()?.transform;

        return nearestTarget != null;
    }

    protected override Vector3 MovementDirection()
    {
        NavMeshPath path = new NavMeshPath();

        // Create a path from the current position to the destination
        if (NavMesh.CalculatePath(transform.position, ai.destination, NavMesh.AllAreas, path) && path.corners.Length > 1)
        {
            // Get the direction to the next corner
            Vector3 direction = (path.corners[1] - transform.position);

            // Prevent moving faster diagonally
            Vector3 normalizedDirection = direction.normalized;

            return normalizedDirection;
        }

        // Fallback: No valid path or ai is already at destination
        return Vector3.zero;
    }
}
