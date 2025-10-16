using UnityEngine;

public class LevelThreeDoor : MonoBehaviour
{
    // Fields

    private bool canProgress = true;

    // Trigger Methods

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && FindFirstObjectByType<BossController>() == null && FindFirstObjectByType<WeaponHealth>() == null && canProgress == true)
        {
            canProgress = false;

            FindFirstObjectByType<SceneTransitionController>().LoadMainMenu();
        }
    }
}
