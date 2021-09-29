using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShootController : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private InputManager inputManager;

    [Range(0, 1)]
    public float visibleAlpha = 0.7f;

    private Color inactiveColor, activeColor;
    private void Start()
    {
        image = GetComponent<Image>();
        inactiveColor = image.color;
        activeColor = new Color(1, 1, 1, 0) * image.color + new Color(0, 0, 0, visibleAlpha);
    }

    public void ShootCannon()
    {
        inputManager.ShootCannon();
    }

    public void ShowButton()
    {
        image.color = activeColor;
    }

    public void HideButton()
    {
        image.color = inactiveColor;
    }

}
