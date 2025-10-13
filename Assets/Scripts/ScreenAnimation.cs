using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenAnimation : MonoBehaviour
{
    // Fields

    public Sprite[] animationFrames;
    public float animationSpeed = 1f;

    private Image image;

    // Methods

    private void Start()
    {
        // Get reference to image
        image = GetComponent<Image>();

        // Start static animation
        StartCoroutine(StaticAnimation());
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
}
