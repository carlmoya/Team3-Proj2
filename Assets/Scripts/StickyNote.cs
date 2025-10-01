using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class StickyNote : MonoBehaviour
{
    // Fields

    public List<string> notes = new List<string>();

    private TMP_Text stickyNoteText;

    // Methods

    private void Start()
    {
        stickyNoteText = GetComponentInChildren<TMP_Text>();

        stickyNoteText.color = RandomColor();

        stickyNoteText.text = RandomNote();
    }

    // Return Methods

    private string RandomNote()
    {
        return notes[Random.Range(0, notes.Count)];
    }

    private Color RandomColor() // Returns black 50% of the time
    {
        int randomNumber = Random.Range(0, 6); // Random.range is max exclusive

        return randomNumber switch
        {
            0 => Color.red,
            1 => Color.blue,
            2 => new Color(0.5f, 0.1f, 1f), // Preset color does not exist for purple
            3 => Color.black,
            4 => Color.black,
            5 => Color.black,
            _ => Color.black
        };
    }
}
