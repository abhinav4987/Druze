using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITurnController : MonoBehaviour
{
    private Image image;


    [SerializeField]
    private InputManager inputManager;

    [Range(0, 1)]
    public float visibleAlpha = 0.7f;

    [SerializeField]
    private bool leftDirection;

    private Color inactiveColor, activeColor;

    private void Start()
    {
        image = GetComponent<Image>();
        inactiveColor = image.color;
        activeColor = image.color * new Color(1, 1, 1, 0) + new Color(0, 0, 0, visibleAlpha);
    }

    public void RotateHandler()
    {
        if (leftDirection) inputManager.RotateLeft();
        else inputManager.RotateRight();
    }

    public void StopRotate()
    {
        inputManager.StopRotation();
    }
}
