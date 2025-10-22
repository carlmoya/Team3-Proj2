using System.Collections;
using UnityEngine;

public abstract class HealthBase : MonoBehaviour
{
    // Fields

    public int health = 1;

    private bool isInvincible = false;

    // Methods

    public void Modify(int amount = 0) // Default parameter is 0
    {
        if (isInvincible == true) { return; }

        // Modify health
        health += amount;

        if (amount < 0)
        {
            TakeDamage();

            StartCoroutine(IFrames());
        }

        // Die if health runs out
        if (health <= 0) { Die(); }
    }

    protected virtual void TakeDamage()
    {

    }

    public abstract void Die();

    // Coroutines

    private IEnumerator IFrames()
    {
        isInvincible = true;

        yield return new WaitForSeconds(1.5f);

        isInvincible = false;
    }
}
