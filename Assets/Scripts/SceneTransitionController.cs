using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneTransitionController : MonoBehaviour
{
    // TODO Add Comments

    // Fields

    public bool fadeAudio = true;
    public bool fadeOnStart = true;

    private CanvasGroup canvasGroup;
    private string[] menuScenes = { "MainMenu", "HowToPlay", "Credits" };

    // Methods

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (fadeOnStart == true) { StartCoroutine(FadeCanvasAlpha(1f, 0f)); }

        if (menuScenes.Contains(CurrentScene()))
        {
            Cursor.visible = true; // Hide mouse cursor
            Cursor.lockState = CursorLockMode.Confined; // Lock mouse cursor to the center of the screen
        }
    }

    private void Update()
    {
        HandleDeveloperCheats();

        HandleAudio();
    }

    private void HandleDeveloperCheats()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LoadMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadCredits();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadHowToPlay();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadLevelOne();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LoadLevelTwo();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LoadLevelThree();
        }
    }

    private void HandleAudio()
    {
        // Scale volume with scene transitions if fadeAudio is set to true
        if (fadeAudio == true) { AudioListener.volume = 1f - canvasGroup.alpha; }
    }

    // Button Methods

    public void LoadMainMenu()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation("MainMenu"));
    }

    public void LoadCredits()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation("Credits"));
    }

    public void LoadHowToPlay()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation("HowToPlay"));
    }

    public void LoadLevelOne()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation("Level1"));
    }

    public void LoadLevelTwo()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation("Level2"));
    }
    public void LoadLevelThree()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation("Level3"));
    }

    public void QuitGame()
    {
        StopAllCoroutines();
        StartCoroutine(QuitGameAnimation());
    }

    public void ReloadScene()
    {
        StopAllCoroutines();
        StartCoroutine(SceneLoadAnimation(CurrentScene()));
    }

    // Coroutines

    private IEnumerator SceneLoadAnimation(string scene)
    {
        yield return FadeCanvasAlpha(canvasGroup.alpha, 1);

        SceneManager.LoadScene(scene);
    }

    private IEnumerator QuitGameAnimation()
    {
        yield return FadeCanvasAlpha(canvasGroup.alpha, 1);

        Application.Quit();
    }

    private IEnumerator FadeCanvasAlpha(float startAlpha, float targetAlpha)
    {
        float duration = 0.15f;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime <= duration; elapsedTime += Time.deltaTime)
        {
            float time = elapsedTime / duration; // Normalize elapsedTime

            // Interpolate over time
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, time);

            canvasGroup.alpha = currentAlpha; // Apply animation

            yield return null; // Wait for next frame
        }

        canvasGroup.alpha = targetAlpha; // Ensure finished animation state
    }

    // Return Methods

    public string CurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
