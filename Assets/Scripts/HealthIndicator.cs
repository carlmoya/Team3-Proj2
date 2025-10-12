using TMPro;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    // Fields

    private PlayerHealth playerHealth;

    // Methods

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    private void Update()
    {
        //text.text = $"Your doing great! You have {playerHealth.health} health.";
    }
}
