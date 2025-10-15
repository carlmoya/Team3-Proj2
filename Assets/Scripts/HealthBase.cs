using UnityEngine;

public abstract class HealthBase : MonoBehaviour
{
    // Fields

    public int health = 1;

    // Methods

    public void Modify(int amount = 0) // Default parameter is 0
    {
        // Modify health
        health += amount;

        if (amount < 0)
        {
            TakeDamage();
        }

        // Die if health runs out
        if (health <= 0) { Die(); }
    }

    protected virtual void TakeDamage()
    {

    }

    public abstract void Die();
}
