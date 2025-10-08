using UnityEngine;

public class SceneSwitchTrigger : MonoBehaviour
{
    // TODO Add comments
    // TODO Simplify logic

    // Fields

    private bool isSwitching = false;

    // Methods

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && FindFirstObjectByType<PlayerGrab>().GrabbingTreasure() == true && isSwitching == false)
        {
            isSwitching = true;

            SceneTransitionController sceneTransitionController = GameObject.FindFirstObjectByType<SceneTransitionController>();

            switch (sceneTransitionController.CurrentScene())
            {
                case "Level1":
                    sceneTransitionController.LoadLevelTwo();
                    break;
                case "Level2":
                    sceneTransitionController.LoadLevelThree();
                    break;
                default:
                    break;
            }
        }
    }
}
