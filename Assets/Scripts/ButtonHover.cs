using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // TODO Add comments

    // Fields

    private Image buttonImage;

    // Methods

    private void Start()
    {
        buttonImage = transform.GetComponentsInChildren<Image>()
            .Where(image => image.gameObject != gameObject)
            .FirstOrDefault();

        buttonImage.canvasRenderer.SetAlpha(0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.CrossFadeAlpha(1f, 0.1f, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.CrossFadeAlpha(0f, 0.1f, true);
    }
}