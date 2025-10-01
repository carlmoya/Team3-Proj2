using UnityEngine;

public class Rainbow
{
    // Fields

    private int currentColorNumber;

    private Color orange = new Color(1f, 0.5f, 0f); // Preset color does not exist for orange
    private Color purple = new Color(0.5f, 0.1f, 1f); // Preset color does not exist for purple

    // Properties

    public int CurrentColorNumber
    {
        get { return currentColorNumber; }
        set { currentColorNumber = value; }
    }

    public Color Orange
    {
        get { return orange; }
    }

    public Color Purple
    {
        get { return purple; }
    }

    // Methods

    public Color CurrentColor()
    {
        return GetColor(currentColorNumber);
    }

    public Color RandomColor()
    {
        int randomColorNumber = Random.Range(0, 6); // Random.Range is max exclusive

        return GetColor(randomColorNumber);
    }

    private Color GetColor(int colorNumber)
    {
        colorNumber = Mathf.Abs(colorNumber % 6); // Ensure colorNumber does not fall out of range

        return colorNumber switch
        {
            0 => Color.red,
            1 => orange,
            2 => Color.yellow,
            3 => Color.green,
            4 => Color.blue,
            5 => purple,
            _ => Color.black
        };
    }
}
