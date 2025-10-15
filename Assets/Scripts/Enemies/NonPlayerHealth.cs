using UnityEngine;

public class NonPlayerHealth : HealthBase
{
    // Methods

    public override void Die()
    {
        // Spawn death effect
        Destroy(gameObject);
    }
}
