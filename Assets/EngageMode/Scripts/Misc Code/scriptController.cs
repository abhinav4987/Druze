using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptController : MonoBehaviour
{

    private int maxValue;
    scriptController(int maxValue)
    {
        this.maxValue = maxValue;
    }
    // Start is called before the first frame update

   
     public void SetValue(int maxValue)
     {
         this.maxValue = maxValue;
     }
     public int GetValue()
    {
        return maxValue;
    }
    
}
