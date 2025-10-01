using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Fields

    private Image buttonIndicator;

    // Methods

    private void Start()
    {
        // Get a reference to the button indicator
        buttonIndicator = transform.GetComponentsInChildren<Image>()
            .Where(image => image.gameObject != gameObject)
            .FirstOrDefault();

        // Make the button indicator invisible
        buttonIndicator.canvasRenderer.SetAlpha(0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Make the button indicator visible
        buttonIndicator.CrossFadeAlpha(1f, 0.1f, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Make the button indicator invisible
        buttonIndicator.CrossFadeAlpha(0f, 0.1f, true);
    }
}