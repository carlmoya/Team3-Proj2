using UnityEngine;

public class LevelTwoIntroDialogue : MonoBehaviour
{
    // Fields

    private Pager pager;

    // Methods

    private void Start()
    {
        // Get reference to pager
        pager = FindFirstObjectByType<Pager>();

        pager.messageQueue.Add("Boss: hidden in this place is a diamond");

        pager.messageQueue.Add("we need it for Project L.I.F.E");

        pager.messageQueue.Add("we're still the good guys btw lol");
    }
}
