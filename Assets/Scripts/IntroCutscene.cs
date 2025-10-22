using TMPro;
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
        public float secondsOnScreen;
        public string caption;
        public Color captionColor;
    }

    public List<AnimationFrame> animationFrames = new List<AnimationFrame>();

    private Image image;
    private TMP_Text text;

    // Methods

    private void Start()
    {
        // Get reference to image
        image = GetComponent<Image>();

        // Get reference to text
        text = GetComponentInChildren<TMP_Text>();

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

            // Set text to current caption
            text.text = currentFrame.caption;

            // Set text color to caption color
            text.color = new Color(currentFrame.captionColor.r, currentFrame.captionColor.g, currentFrame.captionColor.b, 1);

            // Wait to move to the next frame
            yield return new WaitForSeconds(currentFrame.secondsOnScreen);
        }

        // Load level one
        FindFirstObjectByType<SceneTransitionController>().LoadLevelOne();
    }
}
