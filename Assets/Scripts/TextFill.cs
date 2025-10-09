using TMPro;
using UnityEngine;
using System.Collections;

public class TextFill : MonoBehaviour
{
    // Fields

    public float fillSpeed = 1f;

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
        StartCoroutine(TextFillAnimation());
    }

    // Coroutines

    private IEnumerator TextFillAnimation()
    {
        foreach (char character in textContents)
        {
            // Add the character to text box
            textBox.text += character;

            // Wait to add another character
            yield return new WaitForSeconds(0.025f / fillSpeed);
        }
    }
}
