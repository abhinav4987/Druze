using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHullHealthController : MonoBehaviour
{
    [SerializeField]
    private HullHealthBarController playerHealthBarController;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (playerHealthBarController.IsReady())
            image.fillAmount = playerHealthBarController.GetBarControllerValue();
    }
}
