using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHullHealthController : MonoBehaviour
{
    private GetClosestEnemyInFront closestEnemyGetter;

    private Image image;
    [SerializeField]
    private Image backImage;

    private Color inactiveSelfColor, activeSelfColor, inactiveBackColor, activeBackColor;

    private void Start()
    {
        image = GetComponent<Image>();
        inactiveSelfColor = Color.clear;
        inactiveBackColor = Color.clear;
        activeSelfColor = image.color;
        activeBackColor = backImage.color;
        closestEnemyGetter = GetComponent<GetClosestEnemyInFront>();
    }

    void Update()
    {
        HullHealthBarController enemyHealthBarController = closestEnemyGetter.GetClosestBarController();
        if(enemyHealthBarController == null)
        {
            backImage.color = inactiveBackColor;
            image.color = inactiveSelfColor;
        }
        else if(enemyHealthBarController.IsReady())
        {
            image.fillAmount = enemyHealthBarController.GetBarControllerValue();
            backImage.color = activeBackColor;
            image.color = activeSelfColor;
        }
    }
}
