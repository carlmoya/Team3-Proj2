using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFill : MonoBehaviour
{
    // Fields

    public float fillSpeed = 1f;

    private TMP_Text textBox;
    private string textContents;

    private Image typingIndicator;

    // Methods

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();
        typingIndicator = GetComponentInChildren<Image>();

        // Store the contents of the text box
        textContents = textBox.text;

        // Clear the contents of the text box
        textBox.text = "";

        StartCoroutine(Animate());
    }

    // Coroutines

    private IEnumerator Animate()
    {
        // Wait for the text to fill
        yield return StartCoroutine(TextFillAnimation());

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Fade the typing indicator in and out
        StartCoroutine(TypingIndicatorFadeAnimation());
    }

    private IEnumerator TextFillAnimation()
    {
        foreach (char character in textContents)
        {
            // Add the character to text box
            textBox.text += character;

            // Force mesh update to refresh character info
            textBox.ForceMeshUpdate();

            // Get the character info of the most recent character
            TMP_CharacterInfo characterInfo = textBox.textInfo.characterInfo[textBox.text.Length - 1];

            // Get the line info of the most recent character
            TMP_LineInfo lineInfo = textBox.textInfo.lineInfo[characterInfo.lineNumber];

            // Get the position of in front of the most recent character
            Vector3 lineWorldPosition = new Vector3(lineInfo.lineExtents.max.x + 35f, lineInfo.lineExtents.max.y - 25f, 0f);

            // Move the typing indicator in front of the most recent character
            typingIndicator.transform.localPosition = lineWorldPosition;

            // Wait to add another character
            yield return new WaitForSeconds(0.025f / fillSpeed);
        }
    }

    private IEnumerator TypingIndicatorFadeAnimation()
    {
        bool fadeIn = true;

        while (true) // Runs forever unless stopped
        {
            // Fade the typing indicator in or out over half a second
            typingIndicator.CrossFadeAlpha(fadeIn == true ? 1 : 0, 0.5f, false);

            // Set whether to fade in or out
            fadeIn = !fadeIn;

            // Wait for half a second
            yield return new WaitForSeconds(0.5f);
        }
    }
}
