using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullHealthBarController : MonoBehaviour
{
    private BarController barController = null;
    private Hull hull;

    private void Start()
    {
        hull = GetComponent<Hull>();
        barController = new BarController(hull.GetMaxHealth());
        barController.SetValue(hull.GetCurrentHealth());
        hull.OnDamage += Hull_OnDamage;
    }

    private void Hull_OnDamage(object sender, System.EventArgs e)
    {
        barController.SetValue(hull.GetCurrentHealth());
    }

    public bool IsReady()
    {
        return barController != null;
    }

    public float GetBarControllerValue()
    {
        return barController.GetNormalizedValue();
    }
}
