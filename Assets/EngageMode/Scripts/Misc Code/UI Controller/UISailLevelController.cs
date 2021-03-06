using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISailLevelController : MonoBehaviour
{
    public float threshold = 5f;
    float beginY;
    private Image image;


    [SerializeField]
    private InputManager inputManager;

    [Range(0,1)]
    public float visibleAlpha = 0.7f;

    private Color inactiveColor, activeColor;

    private void Start()
    {
        image = GetComponent<Image>();
        inactiveColor = image.color;
        activeColor = image.color * new Color(1, 1, 1, 0) + new Color(0, 0, 0, visibleAlpha);
    }

    public void SetY()
    {
        beginY = Input.mousePosition.y;
        image.color = activeColor;
    }

    public void SwipeHandler()
    {

        float diffY = Input.mousePosition.y - beginY;

        if(Mathf.Abs(diffY) > threshold)
        {
            inputManager.ChangeSailLevel(diffY > 0);
        }

        image.color = inactiveColor;
    }
}
