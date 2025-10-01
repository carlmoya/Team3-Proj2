using TMPro;
using UnityEngine;
using System.Collections;

public class TextFill : MonoBehaviour
{
    // Fields

    private TMP_Text textBox;
    private string textContents;

    // Methods

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();

        // Store the contents of the text box
        textContents = textBox.text;

        // Clear the contents of the text box
        textBox.text = "";

        // Fill the text box
        StartCoroutine(TextFillAnimation(textContents));
    }

    private IEnumerator TextFillAnimation(string textContents)
    {
        foreach (char character in textContents)
        {
            // Add the character to text box
            textBox.text += character;

            // Wait for a fraction of a second
            yield return new WaitForSeconds(0.025f);
        }
    }
}
