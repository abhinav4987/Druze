using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHullHealthController : MonoBehaviour
{
    [SerializeField]
    private HullHealthBarController enemyHealthBarController;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (enemyHealthBarController.IsReady())
            image.fillAmount = enemyHealthBarController.GetBarControllerValue();
    }
}
