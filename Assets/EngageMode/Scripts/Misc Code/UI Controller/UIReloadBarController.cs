using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReloadBarController : MonoBehaviour
{
    private BarController barController = null;
    private UIShootController shootButton;

    [SerializeField]
    private InputManager inputManager;

    private Image image;

    IEnumerator Waiter()
    {
        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            if (inputManager.GetIsCannonBuilt())
                break;
        }
        barController = new BarController(inputManager.GetReloadTime());
        barController.SetValue(0);
        yield return null;
    }

    private void Start()
    {
        image = GetComponent<Image>();
        shootButton = transform.parent.GetComponentInChildren<UIShootController>();
        image.fillAmount = 0;
        StartCoroutine(Waiter());
    }

    private void Update()
    {
        if(barController != null)
        {
            if (barController.GetNormalizedValue() == 0)
                shootButton.ShowButton();
            else
                shootButton.HideButton();
        }
    }

    private void FixedUpdate()
    {
        if (barController != null)
        {
            barController.SetValue(inputManager.GetCurrentReloadTime());
            image.fillAmount = 1.0f - barController.GetNormalizedValue();
        }
    }
}
