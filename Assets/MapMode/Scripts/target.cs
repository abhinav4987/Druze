using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class target : MonoBehaviour
{
    public Transform Target;
    public float HideDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Target.position - transform.position;

        

            var angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
    }
}
