using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class StickyNote : MonoBehaviour
{
    // TODO Add comments

    // Fields

    private TMP_Text stickyNoteText;
    public List<string> notes = new List<string>();

    public static string currentNote = null;
    public static Color currentColor = Color.white;

    // Methods

    private void Start()
    {
        stickyNoteText = GetComponentInChildren<TMP_Text>();

        if (currentNote == null) { currentNote = RandomNote(); }

        if (currentColor == Color.white) { currentColor = RandomColor(); }

        SetNote();
    }

    public void ChangeNote()
    {
        string newNote = currentNote;

        do { newNote = RandomNote(); } while (newNote == currentNote);

        currentNote = newNote;

        Color newColor = currentColor;

        do { newColor = RandomColor(); } while (newColor == currentColor);

        currentColor = newColor;

        SetNote();
    }

    private void SetNote()
    {
        stickyNoteText.text = currentNote;
        stickyNoteText.color = currentColor;
    }

    // Return Methods

    private string RandomNote()
    {
        return notes[Random.Range(0, notes.Count)];
    }

    private Color RandomColor()
    {
        int randomNumber = Random.Range(0, 6);

        return randomNumber switch
        {
            0 => Color.red,
            1 => Color.blue,
            2 => new Color(0.5f, 0.1f, 1f), // Preset color does not exist for purple
            _ => Color.black
        };
    }
}
