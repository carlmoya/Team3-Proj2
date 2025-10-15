using UnityEngine;

public class BossHealth : HealthBase
{
    // Methods

    public override void Die()
    {
        // Load the main menu
        FindFirstObjectByType<SceneTransitionController>().LoadMainMenu();
    }
}