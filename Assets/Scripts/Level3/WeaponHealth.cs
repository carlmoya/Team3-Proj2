using UnityEngine;

public class WeaponHealth : HealthBase
{
    // Methods

    public override void Die()
    {
        FindFirstObjectByType<Timer>().StopTimer();

        Destroy(gameObject);
    }
}
