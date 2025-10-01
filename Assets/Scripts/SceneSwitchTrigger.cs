using UnityEngine;

public class SceneSwitchTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Treasure"))
        {
            SceneTransitionController sceneTransitionController = GameObject.FindFirstObjectByType<SceneTransitionController>();

            switch (sceneTransitionController.CurrentScene())
            {
                case "Level1":
                    sceneTransitionController.LoadLevelTwo();
                    break;
                default:
                    break;
            }
        }
    }
}
