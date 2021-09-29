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

    private Color inactiveColor, activeColor;

    private void Start()
    {
        parentRectTransform = transform.parent.parent.gameObject.GetComponent<RectTransform>();
        rectTransform = transform.parent.GetComponent<RectTransform>();
        image = GetComponent<Image>();
        activeColor = new Color(1, 1, 1, 0) * image.color + new Color(0, 0, 0, visibleAlpha);
        inactiveColor = image.color;
    }
    public void SetIdentifierPosition()
    {
        image.color = activeColor;
        float parentOffset = (Screen.height - parentRectTransform.rect.height) * 0.5f;
        float mouseY = 0;
        if (Input.touchCount > 0)
            mouseY = Input.GetTouch(0).position.y - parentOffset;
        else
            mouseY = Input.mousePosition.y - parentOffset;
        mouseY = Mathf.Clamp(mouseY / (Screen.height - 2 * parentOffset), 0, 1);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, mouseY * parentRectTransform.rect.height);

        inputManager.SetCannonAngle(mouseY);
    }

    public void HideIndicator()
    {
        image.color = inactiveColor;
    }
}
