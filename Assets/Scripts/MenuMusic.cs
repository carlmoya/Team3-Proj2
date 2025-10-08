using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    // TODO Add comments
    // TODO Destroy when traveling away from menu scenes

    // Fields

    public static MenuMusic instance;

    // Methods

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            Destroy(gameObject);
        }
    }
}
