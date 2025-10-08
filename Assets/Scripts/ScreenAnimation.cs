using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenAnimation : MonoBehaviour
{
    // TODO Add comments

    // Fields

    public Sprite[] animationFrames;
    public float animationSpeed = 1f;

    private Image image;

    // Methods

    private void Start()
    {
        image = GetComponent<Image>();

        StartCoroutine(StaticAnimation());
    }

    // Coroutines

    private IEnumerator StaticAnimation()
    {
        int currentFrame = 0;

        while (true) // Runs forever unless stopped
        {
            image.sprite = animationFrames[currentFrame];

            currentFrame = (currentFrame + 1) % animationFrames.Length;

            yield return new WaitForSeconds(0.05f / animationSpeed);
        }
    }
}
