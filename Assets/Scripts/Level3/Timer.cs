using TMPro;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    // Fields

    public float timeLeft = 180f;

    public Transform lvsl3musik;

    private TMP_Text timerText;

    // Methods

    private void Start()
    {
        // Get reference to timer text
        timerText = GetComponent<TMP_Text>();

        // Start color animation
        StartCoroutine(ColorAnimation());

        // Start count down animation
        StartCoroutine(CountDownAnimation());
    }

    public void StopTimer()
    {
        // Stop countdown and color animations
        StopAllCoroutines();

        GetComponent<AudioSource>().Play();
        Destroy(lvsl3musik.gameObject);
    }

    // Coroutines

    private IEnumerator CountDownAnimation()
    {
        while (true) // Runs forever unless stopped
        {
            // Subtract 1 from time left
            timeLeft = Mathf.Max(timeLeft - 1f, 0f);

            // If there's no time left
            if (timeLeft <= 0f)
            {
                // Reload the scene
                FindFirstObjectByType<SceneTransitionController>().ReloadScene();
            }

            // Get time left in minutes
            int minutesLeft = Mathf.FloorToInt(timeLeft / 60);

            // Get time left in seconds
            int secondsLeft = Mathf.FloorToInt(timeLeft % 60);

            // Display time left
            timerText.text = string.Format("COUNTDOWN: " + "{0:00}:{1:00}", minutesLeft, secondsLeft);

            // Wait for 1 second
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ColorAnimation()
    {
        // Customize animation duration
        float duration = timeLeft;

        // Get start color
        Color startColor = timerText.color;

        // Get target color
        Color targetColor = Color.red;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / duration;

            // Interpolate over time
            Color currentColor = Color.Lerp(startColor, targetColor, time);

            // Apply animation
            timerText.color = currentColor;

            // Wait for next frame
            yield return null;
        }

        // Ensure finished animation state
        timerText.color = targetColor;
    }
}
