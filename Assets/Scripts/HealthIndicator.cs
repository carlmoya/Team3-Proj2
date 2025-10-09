using TMPro;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    // Fields

    private TMP_Text text;

    private PlayerHealth playerHealth;

    // Methods

    private void Start()
    {
        text = GetComponent<TMP_Text>();

        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    private void Update()
    {
        text.text = $"Your doing great! You have {playerHealth.health} health.";
    }
}
