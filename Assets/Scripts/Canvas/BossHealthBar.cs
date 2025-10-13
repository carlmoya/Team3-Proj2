using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealthBar : MonoBehaviour
{
    // Fields

    public Transform line;
    public TMP_Text healthPercentage;

    public Sprite[] animationFrames;
    public float animationSpeed = 1f;

    private Image image;
    private Coroutine fillAnimation = null;

    // Methods

    private void Start()
    {
        // Get reference to image
        image = GetComponent<Image>();

        // Start static animation
        StartCoroutine(StaticAnimation());
    }

    private void Update()
    {
        UpdateHealthPercentage();
        UpdateLine();
    }

    public void AnimateFill(float targetFill)
    {
        // Stop any running fill animation
        if (fillAnimation != null) { StopCoroutine(fillAnimation); }

        // Start a new fill animation
        fillAnimation = StartCoroutine(FillAnimation(targetFill));
    }

    private void UpdateHealthPercentage()
    {
        // Display image fill amount as a percentage of boss health
        healthPercentage.text = $"BOSS INTEGRITY: {Mathf.Round(image.fillAmount * 100f)}%";
    }

    private void UpdateLine()
    {
        // Get the rect transform of the image
        RectTransform rectTransform = image.rectTransform;

        // Get the full width of the rect transform
        float fullWidth = rectTransform.rect.width;

        // Get the width of the filled portion
        float filledWidth = rectTransform.rect.width * image.fillAmount;

        // Get the offset from the center pivot to left edge
        float leftEdgeOffset = -fullWidth * 0.5f;

        // Get the local X position of the right edge
        float localX = leftEdgeOffset + filledWidth;

        // Convert local position to world position
        Vector3 localPoint = new Vector3(localX, 0, 0);
        Vector3 worldPoint = rectTransform.TransformPoint(localPoint);

        // Move line to the right edge of the image
        line.position = worldPoint;
    }

    // Coroutines

    private IEnumerator StaticAnimation()
    {
        // Set current frame to the first frame
        int currentFrame = 0;

        while (true) // Runs forever unless stopped
        {
            // Set image to current frame
            image.sprite = animationFrames[currentFrame];

            // Increase current frame
            currentFrame = (currentFrame + 1) % animationFrames.Length;

            // Wait to set image to current frame
            yield return new WaitForSeconds(0.05f / animationSpeed);
        }
    }

    private IEnumerator FillAnimation(float targetFill)
    {
        // Get start fill
        float startFill = image.fillAmount;

        // Customize animation duration
        float duration = 0.1f;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / duration;

            // Interpolate over time
            float currentFill = Mathf.Lerp(startFill, targetFill, time);

            // Apply animation
            image.fillAmount = currentFill;

            // Wait for next frame
            yield return null;
        }

        // Ensure finished animation state
        image.fillAmount = targetFill;
    }
}
