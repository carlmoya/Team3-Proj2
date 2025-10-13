using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reticle : MonoBehaviour
{
    // Fields

    public Image reticleFill;

    private PlayerGrab playerGrab;

    private Color normalColor = Color.white;
    private Vector3 normalScale = Vector3.one;

    private Color accentColor = Color.green;
    private Vector3 accentScale = Vector3.one * 2f;

    private Color targetColor;
    private Vector3 targetScale;

    // Methods

    private void Start()
    {
        // Get reference to player grab
        playerGrab = FindFirstObjectByType<PlayerGrab>();

        // Initialize target color
        targetColor = normalColor;

        // Initialize target scale
        targetScale = normalScale;

        // Start reticle color animation
        StartCoroutine(ColorAnimation());

        // Start reticle scale animation
        StartCoroutine(ScaleAnimation());
    }

    private void Update()
    {
        UpdateTargets();
    }

    private void UpdateTargets()
    {
        // If the player is not grabbing anything and looking at a grabbable object
        if (playerGrab.GrabbingSomething() == false && playerGrab.Target() != null)
        {
            // Set target scale to accent scale
            targetScale = accentScale;

            // Set target color to accent color
            targetColor = accentColor;
        }
        else
        {
            // Set target scale to normal scale
            targetScale = normalScale;

            // Set target color to normal color
            targetColor = normalColor;
        }
    }

    // Coroutines

    private IEnumerator ColorAnimation()
    {
        while (true) // Runs forever unless stopped
        {
            // If the current color is not the target color
            if (reticleFill.color != targetColor)
            {
                // Move the current color towards the target color
                reticleFill.color = Color.Lerp(reticleFill.color, targetColor, 0.1f);
            }

            // Wait before trying to move the current color again
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator ScaleAnimation()
    {
        while (true) // Runs forever unless stopped
        {
            // If the current scale is not the target scale
            if (transform.localScale != targetScale)
            {
                // Move the current scale towards the target scale
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.1f);
            }

            // Wait before trying to move the current scale again
            yield return new WaitForSeconds(0.01f);
        }
    }
}
