using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthBase
{
    // Methods

    public override void Die()
    {
        FindFirstObjectByType<SceneTransitionController>().ReloadScene();
    }
}
