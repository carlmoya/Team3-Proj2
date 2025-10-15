using UnityEngine;

public class LevelThreeDoor : MonoBehaviour
{
    // Trigger Methods

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && FindFirstObjectByType<BossController>() == null && FindFirstObjectByType<WeaponHealth>() == null)
        {
            FindFirstObjectByType<SceneTransitionController>().LoadMainMenu();
        }
    }
}
