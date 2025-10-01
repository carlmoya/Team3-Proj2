using UnityEngine;

public class BiteDamage : MonoBehaviour
{
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneTransitionController sceneTransitionController = GameObject.FindFirstObjectByType<SceneTransitionController>();

            sceneTransitionController.ReloadScene();
        }
    }
}
