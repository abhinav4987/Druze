using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAngleController : MonoBehaviour
{
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;

    private Image image;

    [Range(0,1)]
    public float visibleAlpha;

    [SerializeField]
    private InputManager inputManager;

    private void Start()
    {
        parentRectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    public void SetIdentifierPosition()
    {
        image.color = new Color(1, 1, 1, 0) * image.color + new Color(0, 0, 0, visibleAlpha);
        float parentOffset = (Screen.height - parentRectTransform.rect.height);
        float mouseY = Input.mousePosition.y - parentOffset;
        mouseY = Mathf.Clamp(mouseY / (Screen.height - 2 * parentOffset), 0, 1);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, mouseY * parentRectTransform.rect.height);

        inputManager.SetCannonAngle(mouseY);
    }

    public void HideIndicator()
    {
        image.color = new Color(1, 1, 1, 0) * image.color;
    }
}
