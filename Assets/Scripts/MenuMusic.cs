using UnityEngine;

public class MenuMusic : MonoBehaviour
{
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
}
