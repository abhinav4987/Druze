using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpyGlassController : MonoBehaviour
{
    [SerializeField]
    private GameObject spyGlassParent;

    public void ShowSpyGlass()
    {
        spyGlassParent.SetActive(true);
    }

    public void HideSpyGlass()
    {
        spyGlassParent.SetActive(false);
    }

}
