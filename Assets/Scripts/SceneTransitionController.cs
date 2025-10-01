using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    // TODO Add Comments
    // TODO Add developer cheats

    // Fields

    private CanvasGroup canvasGroup;

    // Methods

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(FadeCanvasAlpha(1f, 0f));
    }

    private void Update()
    {
        AudioListener.volume = CurrentVolume();
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

    private float CurrentVolume()
    {
        return 1f - canvasGroup.alpha; // Scale volume with scene transitions
    }

    public string CurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
