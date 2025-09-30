using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyMovement : MovementBase
{
    // TODO Allow moving when on the ground & grabbed by player
    // TODO Allow throwing by player
    // TODO Streamline into NPC Movement script
    // TODO Rotate towards movement direction
    // TODO Make agent avoid other nearby agents to prevent pile-ups

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

        DrawDebugLine();
    }

    protected void FixedUpdate() // Not ran every frame to avoid issues w/ physics
    {
        base.Move();
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

    protected void DrawDebugLine()
    {
        Debug.DrawLine(base.rb.position, base.rb.position + base.rb.linearVelocity, Color.red);
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 1f), Color.green);
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
