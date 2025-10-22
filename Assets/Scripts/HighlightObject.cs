using UnityEngine;
using System.Collections;

public class HighlightObject : MonoBehaviour
{
    // Fields

    public float colorOffset = 0.1f;

    private Renderer objectRenderer;

    // Methods

    private void Start()
    {
        // Get reference to renderer
        objectRenderer = GetComponent<Renderer>();

        // Go thru each material
        foreach (Material material in objectRenderer.sharedMaterials)
        {
            // Start pulse animation
            StartCoroutine(PulseAnimationLoop(material));
        }
    }

    // Coroutines

    private IEnumerator PulseAnimationLoop(Material material)
    {
        // Get normal color
        Color normalColor = material.color;

        // Track state of animation
        bool goingLight = false;

        while (true) // Runs forever unless stopped
        {
            // Toggle state
            goingLight = !goingLight;

            // Get target color based on state
            Color targetColor = goingLight ? LightVariant(normalColor) : normalColor;

            // Start animation & wait for it to finish
            yield return StartCoroutine(PulseAnimation(material, targetColor));
        }
    }

    private IEnumerator PulseAnimation(Material material, Color targetColor)
    {
        // Customize animation duration
        float duration = 1f;

        // Get the start color
        Color startColor = material.color;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime <= duration; elapsedTime += Time.deltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / duration;

            // Interpolate over time
            Color currentColor = Color.Lerp(startColor, targetColor, time);

            // Apply animation
            material.color = currentColor;

            // Wait for next frame
            yield return null;
        }

        // Ensure finished animation state
        material.color = targetColor;
    }

    // Return Methods

    private Color LightVariant(Color normalColor)
    {
        return new Color(
            Mathf.Clamp01(normalColor.r + colorOffset),
            Mathf.Clamp01(normalColor.g + colorOffset),
            Mathf.Clamp01(normalColor.b + colorOffset),
            normalColor.a);
    }
}
