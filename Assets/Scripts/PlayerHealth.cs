using UnityEngine;

public class PlayerHealth : HealthBase
{
    // Methods

    public override void Die()
    {
        // Get reference to scene transition controller
        SceneTransitionController sceneTransitionController = FindFirstObjectByType<SceneTransitionController>();

        sceneTransitionController.ReloadScene();
    }
}
