using UnityEngine;

public abstract class HealthBase : MonoBehaviour
{
    // Fields

    [SerializeField] private int health = 1;

    // Methods

    public void Modify(int amount = 0) // Default parameter is 0
    {
        // Modify health
        health += amount;

        // Die if health runs out
        if (health <= 0) { Die(); }
    }

    public abstract void Die();
}
