using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntroCutscene : MonoBehaviour
{
    // Fields

    [System.Serializable]
    public class AnimationFrame
    {
        public Sprite frame;
        public float secondsOnScreen = 1f;
    }

    public List<AnimationFrame> animationFrames = new List<AnimationFrame>();

    private Image image;

    // Methods

    private void Start()
    {
        // Get reference to image
        image = GetComponent<Image>();

        // Start cutscene animation
        StartCoroutine(CutsceneAnimation());
    }

    // Coroutines

    private IEnumerator CutsceneAnimation()
    {
        // Go thru each frame in animation frames
        foreach (AnimationFrame currentFrame in animationFrames)
        {
            // Set image to current frame
            image.sprite = currentFrame.frame;

            // Wait to move to the next frame
            yield return new WaitForSeconds(currentFrame.secondsOnScreen);
        }

        // Load level one
        FindFirstObjectByType<SceneTransitionController>().LoadLevelOne();
    }
}
