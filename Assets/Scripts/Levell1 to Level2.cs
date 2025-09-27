using UnityEngine;
using UnityEngine.SceneManagement;

public class Levell1toLevel2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("treasure1"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
