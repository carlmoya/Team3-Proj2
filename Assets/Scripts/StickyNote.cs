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
        return Random.Range(0, 2) == 0 ? Color.black : new Rainbow().RandomColor();
    }
}
